using ControleBovideoSquad.Domain.Entities.Vendas;

namespace ControleBovideoSquad.Domain.Repositories.Vendas
{
    public interface IFinalidadeDeVendaRepository
    {
        List<FinalidadeDeVenda> ObterTodos();
        FinalidadeDeVenda ObterPorId(int id);
    }
}
