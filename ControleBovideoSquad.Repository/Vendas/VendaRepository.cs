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
        public Venda ObterPorId(int id)
        {
            return _unityOfWork
                .Query<Venda>().FirstOrDefault(x => x.IdVenda == id);
        }

        public List<Venda> ObterPorCpfProdutor(string cpf)
        {
            return _unityOfWork.Query<Venda>().Where(x => x.PropriedadeOrigem.Produtor.CPF == cpf && x.Ativo == true).OrderBy(x => x.PropriedadeOrigem.Nome).ToList();
        }

        public List<Venda> ObterTodos()
        {
            return _unityOfWork.Query<Venda>().Where(x => x.Ativo == true).OrderBy(x => x.PropriedadeOrigem.Nome).ToList();    
        }

        public void Salvar(Venda venda) 
        {
            _unityOfWork.SaveOrUpdate(venda);
        }

    }
}
