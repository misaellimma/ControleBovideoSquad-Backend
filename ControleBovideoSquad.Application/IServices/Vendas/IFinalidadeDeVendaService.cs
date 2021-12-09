using ControleBovideoSquad.Domain.Entities.Vendas;

namespace ControleBovideoSquad.Application.IServices.Vendas
{
    public interface IFinalidadeDeVendaService
    {
        List<FinalidadeDeVenda> ObterTodos();
        FinalidadeDeVenda? Obter(int id);
    }
}
