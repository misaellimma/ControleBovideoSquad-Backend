using ControleBovideoSquad.Application.IMapper.RegistroVacinas;
using ControleBovideoSquad.Application.IServices.Vacinacao;
using ControleBovideoSquad.Application.Validators.Vacinacao;
using ControleBovideoSquad.CrossCutting;
using ControleBovideoSquad.CrossCutting.Dto.Vacinacao;
using ControleBovideoSquad.CrossCutting.Util;
using ControleBovideoSquad.Domain.Entities.Animais;
using ControleBovideoSquad.Domain.Entities.Vacinacao;
using ControleBovideoSquad.Domain.Entities.Vendas;
using ControleBovideoSquad.Domain.Repositories.Animais;
using ControleBovideoSquad.Domain.Repositories.Vendas;
using ControleBovideoSquad.Domain.Repositories.Vacinacao;

namespace ControleBovideoSquad.Application.Services.Animais
{
    public class RegistroVacinaService : IRegistroVacinaService
    {
        private readonly IRegistroVacinaRepository _registroVacinaRepository;
        private readonly IRegistroVacinaDtoMapper _registroMapper;        
        private readonly IRebanhoRepository _rebanhoRepository;
        private readonly IRegistroVacinaValidator _registroVacinaValidator;
        private readonly IVendaRepository _vendaRepository;

        public RegistroVacinaService(IRegistroVacinaRepository registroVacinaRepository,
            IRegistroVacinaDtoMapper registroMapper,            
            IRebanhoRepository rebanhoRepository,
            IRegistroVacinaValidator registroVacinaValidator,
            IVendaRepository vendaRepository
            )
        {
            _registroVacinaRepository = registroVacinaRepository;
            _registroMapper = registroMapper;            
            _rebanhoRepository = rebanhoRepository;
            _registroVacinaValidator = registroVacinaValidator;
            _vendaRepository = vendaRepository;
        }

        public Result<string> Cancelar(int id)
        {
            RegistroVacina? registroVacina= _registroVacinaRepository.Obter(id);

            if (registroVacina == null)
                return Result<string>.Error(EStatusCode.NOT_FOUND, "");

            Rebanho rebanho = _rebanhoRepository.ObterPorId(registroVacina.Rebanho.IdRebanho);
            List<Venda> venda = _vendaRepository.ObterVendaPorProdutor(rebanho.Propriedade.Produtor.CPF)
              .Where(x => x.PropriedadeOrigem.IdPropriedade == registroVacina.Rebanho.Propriedade.IdPropriedade).ToList();

            if (venda.Count != 0)
            {
                if (venda.Last().DataDeVenda.CompareTo(registroVacina.DataDeCadastro) > 0)
                    return Result<string>.Error(EStatusCode.BAD_REQUEST, "Existe uma venda posterior a esta vacina e ela não pode ser cancelada!");

            }

            if (registroVacina.Vacina.IdVacina == 2)
            {
                rebanho.DebitarAftosa(registroVacina.Quantidade);
            }
            else if (registroVacina.Vacina.IdVacina == 1)
            {
                rebanho.DebitarBrucelose(registroVacina.Quantidade);
            }
            registroVacina.Cancelar();

            _rebanhoRepository.Salvar(rebanho);
            _registroVacinaRepository.Salvar(registroVacina);

            return Result<string>.Success("");
        }

        public Result<RegistroVacina> Incluir(RegistroVacinaDto registroVacinaDto)
        {
            Rebanho rebanho = _rebanhoRepository.ObterPorId(registroVacinaDto.IdRebanho);          

            _registroVacinaValidator.IsValid(registroVacinaDto);
            _registroVacinaValidator.VerificarQuantidade(registroVacinaDto,rebanho);

            var validation = _registroVacinaValidator.errors;

            if (validation.Any())
                return Result<RegistroVacina>.Error(EStatusCode.BAD_REQUEST, validation);


            if(registroVacinaDto.IdVacina == 2)
            {
                rebanho.AdicionarAftosa(registroVacinaDto.Quantidade);
            }
            else if(registroVacinaDto.IdVacina == 1)
            {
                rebanho.AdicionarBrucelose(registroVacinaDto.Quantidade);
            }

            _rebanhoRepository.Salvar(rebanho);
            _registroVacinaRepository.Salvar(_registroMapper.MapearDtoParaEntidade(registroVacinaDto));          

            return Result<RegistroVacina>.Success(_registroMapper.MapearDtoParaEntidade(registroVacinaDto));
        }

        public List<RegistroVacinaDto> ObterPorPropriedade(string inscricaoEstadual)
        {
            var registros = _registroVacinaRepository.ObterPorPropriedade(inscricaoEstadual);
            var result = _registroMapper.MapearListaParaEntidadeDto(registros);

            return result;
        }             
    }
}
