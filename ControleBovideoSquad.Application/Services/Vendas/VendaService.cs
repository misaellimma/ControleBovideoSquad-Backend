using ControleBovideoSquad.Application.IMapper.Vendas;
using ControleBovideoSquad.Application.IServices.Vendas;
using ControleBovideoSquad.CrossCutting.Dto.Vendas;
using ControleBovideoSquad.CrossCutting.Enums;
using ControleBovideoSquad.CrossCutting.Util;
using ControleBovideoSquad.Domain.Entities.Animais;
using ControleBovideoSquad.Domain.Entities.Propriedades;
using ControleBovideoSquad.Domain.Entities.Vendas;
using ControleBovideoSquad.Domain.Repositories.Animais;
using ControleBovideoSquad.Domain.Repositories.Propriedades;
using ControleBovideoSquad.Domain.Repositories.Vendas;

namespace ControleBovideoSquad.Application.Services.Vendas
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IEspecieRepository _especieRepository;
        private readonly IRebanhoRepository _rebanhoRepository;
        private readonly IPropriedadeRepository _propriedadeRepository;
        private readonly IFinalidadeDeVendaRepository _finalidadeDeVendaRepository;
        private readonly IVendaMapper _vendaMapper;

        public VendaService(IVendaRepository vendaRepository, IEspecieRepository especieRepository,
            IFinalidadeDeVendaRepository finalidadeDeVendaRepository, IPropriedadeRepository propriedadeRepository,
            IVendaMapper vendaMapper, IRebanhoRepository rebanhoRepository)
        {
            _vendaRepository = vendaRepository;
            _rebanhoRepository = rebanhoRepository;
            _especieRepository = especieRepository;
            _finalidadeDeVendaRepository = finalidadeDeVendaRepository;
            _propriedadeRepository = propriedadeRepository;
            _vendaMapper = vendaMapper;
        }

        public Venda ObterPorId(int id)
        {
            return _vendaRepository.ObterPorId(id);
        }

        public List<Venda> ObterPorCpfProdutor(string cpf)
        {
            return _vendaRepository.ObterPorCpfProdutor(cpf);
        }

        public List<Venda> ObterTodos()
        {
            return _vendaRepository.ObterTodos();
        }

        public Result<Venda> Salvar(VendaDto vendaDto)
        {
            var response = ValidarVenda(vendaDto);

            if (response.Any())
                return Result<Venda>.Error(EStatusCode.BAD_REQUEST, response);

            Venda venda = _vendaMapper.MapearDtoParaEntidade(vendaDto);
            // Adicionar no rebanho da propriedade de destino e tirar do rebanho da propriedade de origem;
            Rebanho rebanhoNaOrigem = _rebanhoRepository.ObterPorPropriedadeEEspecie(venda.PropriedadeOrigem.InscricaoEstadual, venda.Especie.IdEspecie);
            rebanhoNaOrigem.DebitarNoRebanho(vendaDto.Quantidade, vendaDto.Quantidade);
            _rebanhoRepository.Salvar(rebanhoNaOrigem);

            Rebanho rebanhoNoDestino = _rebanhoRepository.ObterPorPropriedadeEEspecie(venda.PropriedadeDestino.InscricaoEstadual,
                venda.Especie.IdEspecie);

            if (rebanhoNoDestino == null)
                _rebanhoRepository.Salvar(new Rebanho(0, vendaDto.Quantidade, vendaDto.Quantidade, vendaDto.Quantidade
                    , venda.Especie, venda.PropriedadeDestino));
            else
            {
                rebanhoNoDestino.AdicionarNoRebanho(vendaDto.Quantidade, vendaDto.Quantidade);
                _rebanhoRepository.Salvar(rebanhoNoDestino);
            }

            _vendaRepository.Salvar(venda);

            return Result<Venda>.Success(venda);
        }

        public Result<string> Cancelar(int id)
        {
            Venda venda = _vendaRepository.ObterPorId(id);

            if (venda == null || venda.Ativo == false)
                return Result<string>.Error(EStatusCode.NOT_FOUND, "venda nao encontrada");

            venda.CancelarVenda();
            // Creditar de volta na propriedade de origem
            Rebanho rebanhoNaOrigem = _rebanhoRepository.ObterPorPropriedadeEEspecie(venda.PropriedadeOrigem.InscricaoEstadual, venda.Especie.IdEspecie);
            rebanhoNaOrigem.AdicionarNoRebanho(venda.Quantidade, venda.Quantidade);
            _rebanhoRepository.Salvar(rebanhoNaOrigem);
            // Debitar da propriedade de destino
            Rebanho rebanhoNoDestino = _rebanhoRepository.ObterPorPropriedadeEEspecie(venda.PropriedadeDestino.InscricaoEstadual, venda.Especie.IdEspecie);
            rebanhoNoDestino.DebitarNoRebanho(venda.Quantidade, venda.Quantidade);
            _rebanhoRepository.Salvar(rebanhoNaOrigem);

            _vendaRepository.Salvar(venda);
            return Result<string>.Success("");
        }

        public List<string> ValidarVenda(VendaDto vendaDto)
        {
            List<string> errors = new List<string>();
            Propriedade propriedadeOrigem = _propriedadeRepository.ObterPorId(vendaDto.IdPropriedadeOrigem);
            Propriedade propriedadeDestino = _propriedadeRepository.ObterPorId(vendaDto.IdPropriedadeDestino);
            Rebanho rebanho = _rebanhoRepository.ObterPorPropriedadeEEspecie(propriedadeOrigem.InscricaoEstadual, vendaDto.IdEspecie);
            FinalidadeDeVenda finalidade = _finalidadeDeVendaRepository.ObterPorId(vendaDto.IdFinalidadeDeVenda);
            // verificar se existe propriedade origem e destino
            // verificar na propriedade origem se tem rebanho vacinado disponivel

            if (finalidade == null)
                errors.Add("Finalidade de venda nao encontrada");

            if (propriedadeOrigem == null)
                errors.Add("Propriedade de origem nao encontrada");

            if (propriedadeDestino == null)
                errors.Add("Propriedade de destino nao encontrada");

            if (rebanho == null)
            {
                errors.Add("Rebanho nao encontrado");
            }
            else
            {
                Console.Write(rebanho.QuantidadeTotal);
                if (rebanho.QuantidadeVacinadaAftosa < vendaDto.Quantidade || rebanho.QuantidadeVacinadaBrucelose < vendaDto.Quantidade)
                    errors.Add("Numero insuficiente de rebanhos vacinados");
            }

            return errors;
        }
    }
}
