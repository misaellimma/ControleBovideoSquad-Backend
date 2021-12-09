using ControleBovideoSquad.Domain.Entities.Vacinacao;
using ControleBovideoSquad.Domain.Repositories.Vacinacao;
using ControleBovideoSquad.Repository.Interfaces;

namespace ControleBovideoSquad.Repository.Vacinacao
{
    public class VacinaRepository : IVacinaRepository
    {
        private readonly IUnityOfWork unityOfWork;

        public VacinaRepository(IUnityOfWork unityOfWork)
        {
            this.unityOfWork = unityOfWork;
        }

        public Vacina ObterPorId(int id)
        {
            return unityOfWork
                .Query<Vacina>()
                .FirstOrDefault(e => e.IdVacina == id);
        }

        public List<Vacina> ObterTodos()
        {
            return unityOfWork
                .Query<Vacina>()
                .ToList();
        }
    }
}
