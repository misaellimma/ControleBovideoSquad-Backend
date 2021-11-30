using ControleBovideoSquad.Domain.Entities;
using ControleBovideoSquad.Domain.Repositories.Animais;
using ControleBovideoSquad.Repository.Interfaces;
using ControleBovideoSquad.Repository.Util;
using NHibernate;

namespace ControleBovideoSquad.Repository.Animais
{
    public class EspecieRepository : IEspecieRepository
    {
        private readonly IUnityOfWork _unityOfWork;

        public EspecieRepository(IUnityOfWork unityOfWork)
        {
            this._unityOfWork = unityOfWork;
        }

        public Especie? ObterEspeciePorId(int id)
        {
            return _unityOfWork.Query<Especie>().FirstOrDefault(x => x.IdEspecie == id);
        }

        public List<Especie> ObterTodos()
        {
            return _unityOfWork.Query<Especie>().ToList();            
        }
    }
}
