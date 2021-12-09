using ControleBovideoSquad.Domain.Entities.Vendas;

namespace ControleBovideoSquad.Domain.Repositories.Vendas
{
    public interface IVendaRepository
    {
        List<Venda> ObterTodos();
        Venda ObterPorId(int id);
        List<Venda> ObterPorCpfProdutor(string cpf);
        void Salvar(Venda Venda);
    }
}
