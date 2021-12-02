using ControleBovideoSquad.CrossCutting.Dto.Vendas;
using ControleBovideoSquad.Domain.Entities.Vendas;

namespace ControleBovideoSquad.Application.IMapper.Vendas
{
    public interface IVendaMapper : IMapper<VendaDto, Venda>
    {
        Venda MapearDtoParaEntidade(VendaDto vendaDto);
    }
}