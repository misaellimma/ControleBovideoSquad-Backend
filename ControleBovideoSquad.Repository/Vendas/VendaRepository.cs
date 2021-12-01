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
            return _unityOfWork.Query<Venda>().ToList();
            //return _unityOfWork.Query<Venda>().Where(x => x.PropriedadeOrigem.Produtor.cpf == cpf);
        }

        public List<Venda> ObterVendas()
        {
            return _unityOfWork.Query<Venda>().ToList();    
        }

        public void Save(Venda venda) 
        {
            _unityOfWork.SaveOrUpdate(venda);
        }
    }
}
