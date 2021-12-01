using ControleBovideoSquad.Application.IServices.Vendas;
using ControleBovideoSquad.Application.Mapper.Vendas;
using ControleBovideoSquad.CrossCutting;
using ControleBovideoSquad.CrossCutting.Dto.Vendas;
using ControleBovideoSquad.CrossCutting.Util;
using ControleBovideoSquad.Domain.Entities.Animais;
using ControleBovideoSquad.Domain.Entities.Vendas;
using ControleBovideoSquad.Domain.Repositories.Animais;
using ControleBovideoSquad.Domain.Repositories.Vendas;

namespace ControleBovideoSquad.Application.Services.Vendas
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IRebanhoRepository _rebanhoRepository;
        private readonly IFinalidadeDeVendaRepository _finalidadeDeVendaRepository;
        private readonly VendaMapper _vendaMapper;

        public VendaService(IVendaRepository vendaRepository, IRebanhoRepository rebanhoRepository,
            IFinalidadeDeVendaRepository finalidadeDeVendaRepository)
        {
            _vendaRepository = vendaRepository;
            _rebanhoRepository = rebanhoRepository;
            _finalidadeDeVendaRepository = finalidadeDeVendaRepository;
        }

        public Venda ObterVendaPorId(int id)
        {
            return _vendaRepository.ObterVendaPorId(id);
        }

        public List<Venda> ObterVendaPorProdutor(string cpf)
        {
            return _vendaRepository.ObterVendaPorProdutor(cpf);
        }

        public List<Venda> ObterVendas()
        {
            return _vendaRepository.ObterVendas();
        }

        public Result<Venda> SalvarVenda(VendaDto vendaDto)
        {
            var response = ValidarVenda(vendaDto);

            if (response.Any())
                return Result<Venda>.Error(EStatusCode.BAD_REQUEST, response);
            
            Venda venda = _vendaMapper.MapearDtoParaEntidade(vendaDto);
            _vendaRepository.Save(venda);

            return Result<Venda>.Success(venda);
        }

        public List<string> ValidarVenda(VendaDto vendaDto)
        {
            List<string> errors = new List<string>();
            Rebanho rebanho = _rebanhoRepository.ObterRebanhosPorId(vendaDto.IdRebanho);
            FinalidadeDeVenda finalidade = _finalidadeDeVendaRepository.ObterPorId(vendaDto.IdFinalidadeDeVenda);

            if (rebanho == null)
                errors.Add("Rebanho nao encontrado");

            if (finalidade == null)
                errors.Add("Finalidade de venda nao encontrada");

            return errors;
        }
    }
}
