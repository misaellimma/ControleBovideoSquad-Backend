using ControleBovideoSquad.Domain.Entities.Animais;
using ControleBovideoSquad.Domain.Repositories.Animais;
using ControleBovideoSquad.Repository.Interfaces;

namespace ControleBovideoSquad.Repository.Animais
{
    public class TipoDeEntradaRepository : ITipoDeEntradaRepository
    {
        private readonly IUnityOfWork _unityOfWork;
        public TipoDeEntradaRepository(IUnityOfWork unityOfWork)
        {
            this._unityOfWork = unityOfWork;
        }
        public TipoDeEntrada ObterPorId(int id)
        {
            return this._unityOfWork
                .Query<TipoDeEntrada>()
                .SingleOrDefault(x => x.IdTipoDeEntrada == id);
        }

        public List<TipoDeEntrada> ObterTodos()
        {
            return this._unityOfWork
                .Query<TipoDeEntrada>()
                .ToList();
        }
    }
}
