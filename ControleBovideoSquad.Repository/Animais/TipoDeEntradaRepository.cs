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
        public TipoDeEntrada ObterTipoDeEntradaPorId(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return this._unityOfWork
                .Query<TipoDeEntrada>()
                .SingleOrDefault(x => x.IdTipoDeEntrada == id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public List<TipoDeEntrada> ObterTipos()
        {
            return this._unityOfWork
                .Query<TipoDeEntrada>()
                .ToList();
        }
    }
}
