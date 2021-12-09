using ControleBovideoSquad.Domain.Entities.Enderecos;
using ControleBovideoSquad.Domain.Repositories.Enderecos;
using ControleBovideoSquad.Repository.Interfaces;

namespace ControleBovideoSquad.Repository.Enderecos
{
    public class MunicipioRepository : IMunicipioRepository
    {
        private readonly IUnityOfWork unityOfWork;

        public MunicipioRepository(IUnityOfWork unityOfWork)
        {
            this.unityOfWork = unityOfWork;
        }

        public Municipio ObterPorId(int id)
        {
            return unityOfWork
                .Query<Municipio>()
                .SingleOrDefault(e => e.IdMunicipio == id);
        }

        public List<Municipio> ObterTodos()
        {
            return unityOfWork
                .Query<Municipio>()
                .ToList();
        }
    }
}
