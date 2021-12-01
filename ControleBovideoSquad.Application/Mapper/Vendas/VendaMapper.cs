using ControleBovideoSquad.Application.IMapper;
using ControleBovideoSquad.CrossCutting.Dto.Vendas;
using ControleBovideoSquad.Domain.Entities;
using ControleBovideoSquad.Domain.Entities.Vendas;
using ControleBovideoSquad.Domain.Repositories.Animais;
using ControleBovideoSquad.Domain.Repositories.Vendas;

namespace ControleBovideoSquad.Application.Mapper.Vendas
{
    public class VendaMapper : IMapper<VendaDto, Venda>
    {
        private readonly IFinalidadeDeVendaRepository _finalidadeDeVendaRepository;
        private readonly IRebanhoRepository _rebanhoRepository;

        public VendaMapper(IFinalidadeDeVendaRepository finalidadeDeVendaRepository, IRebanhoRepository rebanhoRepository)
        {
            _finalidadeDeVendaRepository = finalidadeDeVendaRepository;
            _rebanhoRepository = rebanhoRepository;
        }

        public Venda MapearDtoParaEntidade(VendaDto source)
        {
            var finalidadeDeVenda = _finalidadeDeVendaRepository.ObterPorId(source.IdFinalidadeDeVenda);
            var rebanho = _rebanhoRepository.ObterRebanhosPorId(source.IdRebanho);
            return new Venda(source.IdVenda, source.Quantidade, new Propriedade(), new Propriedade(), rebanho,
                finalidadeDeVenda, source.DataDeVenda, source.Ativo);
        }

        public VendaDto MapearEntidadeParaDto(Venda source)
        {
            throw new NotImplementedException();
        }
    }
}