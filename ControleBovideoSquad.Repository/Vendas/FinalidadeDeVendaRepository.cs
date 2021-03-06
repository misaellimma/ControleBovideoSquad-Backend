using ControleBovideoSquad.Domain.Entities.Vendas;
using ControleBovideoSquad.Domain.Repositories.Vendas;
using ControleBovideoSquad.Repository.Interfaces;

namespace ControleBovideoSquad.Repository.Vendas
{
    public class FinalidadeDeVendaRepository : IFinalidadeDeVendaRepository
    {
        private readonly IUnityOfWork _unityOfWork;

        public FinalidadeDeVendaRepository(IUnityOfWork unityOfWork)
        {
            this._unityOfWork = unityOfWork;
        }

        public FinalidadeDeVenda? ObterPorId(int id)
        {
            return _unityOfWork.Query<FinalidadeDeVenda>().FirstOrDefault(x => x.IdFinalidadeDeVenda == id);
        }

        public List<FinalidadeDeVenda> ObterTodos()
        {
            return _unityOfWork.Query<FinalidadeDeVenda>().ToList();
        }
    }
}
