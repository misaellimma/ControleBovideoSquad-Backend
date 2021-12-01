using ControleBovideoSquad.CrossCutting.Dto.Vendas;
using ControleBovideoSquad.CrossCutting.Util;
using ControleBovideoSquad.Domain.Entities.Vendas;

namespace ControleBovideoSquad.Application.IServices.Vendas
{
    public interface IVendaService
    {
        List<Venda> ObterVendas();
        Venda ObterVendaPorId(int id);
        List<Venda> ObterVendaPorProdutor(string cpf);
        Result<Venda> SalvarVenda(VendaDto vendaDto);
    }
}
