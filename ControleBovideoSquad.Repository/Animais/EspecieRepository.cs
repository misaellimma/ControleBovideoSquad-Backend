using ControleBovideoSquad.Domain.Entities.Animais;
using ControleBovideoSquad.Domain.Repositories.Animais;
using ControleBovideoSquad.Repository.Interfaces;

namespace ControleBovideoSquad.Repository.Animais
{
    public class EspecieRepository : IEspecieRepository
    {
        private readonly IUnityOfWork _unityOfWork;

        public EspecieRepository(IUnityOfWork unityOfWork)
        {
            this._unityOfWork = unityOfWork;
        }

        public Especie ObterPorId(int id)
        {
            return _unityOfWork.Query<Especie>().FirstOrDefault(x => x.IdEspecie == id);
        }

        public List<Especie> ObterTodos()
        {
            return _unityOfWork.Query<Especie>().ToList();            
        }
    }
}
