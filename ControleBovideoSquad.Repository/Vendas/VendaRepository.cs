using ControleBovideoSquad.Domain.Entities.Vendas;
using ControleBovideoSquad.Domain.Repositories.Vendas;
using ControleBovideoSquad.Repository.Interfaces;

namespace ControleBovideoSquad.Repository.Vendas
{
    public class VendaRepository : IVendaRepository
    {
        private readonly IUnityOfWork _unityOfWork;

        public VendaRepository(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        public Venda ObterVendaPorId(int id)
        {
            return _unityOfWork
                .Query<Venda>().FirstOrDefault(x => x.IdVenda == id);
        }

        public List<Venda> ObterVendaPorProdutor(string cpf)
        {
            return _unityOfWork.Query<Venda>().Where(x => x.PropriedadeOrigem.Produtor.CPF == cpf && x.Ativo == true).ToList();
        }

        public List<Venda> ObterVendas()
        {
            return _unityOfWork.Query<Venda>().Where(x => x.Ativo == true).ToList();    
        }

        public void Save(Venda venda) 
        {
            _unityOfWork.SaveOrUpdate(venda);
        }

        public void Cancel(Venda venda)
        {
            
        }
    }
}
