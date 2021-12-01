using ControleBovideoSquad.Domain.Entities.Vendas;

namespace ControleBovideoSquad.Domain.Repositories.Vendas
{
    public interface IVendaRepository
    {
        List<Venda> ObterVendas();
        Venda ObterVendaPorId(int id);
        List<Venda> ObterVendaPorProdutor(string cpf);
        void Save(Venda Venda);
    }
}
