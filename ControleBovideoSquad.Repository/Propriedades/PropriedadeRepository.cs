using ControleBovideoSquad.Domain.Entities.Propriedades;
using ControleBovideoSquad.Domain.Repositories.Propriedades;
using ControleBovideoSquad.Repository.Interfaces;

namespace ControleBovideoSquad.Repository.Propriedades
{
    public class PropriedadeRepository : IPropriedadeRepository
    {
        private readonly IUnityOfWork unityOfWork;

        public PropriedadeRepository(IUnityOfWork unityOfWork)
        {
            this.unityOfWork = unityOfWork;
        }

        public void Salvar(Propriedade produtor)
        {
            unityOfWork.SaveOrUpdate(produtor);
        }

        public Propriedade ObterPorId(int id)
        {
            return unityOfWork
                .Query<Propriedade>()
                .FirstOrDefault(e => e.IdPropriedade == id);
        }

        public Propriedade ObterPorInscricaoEstadual(string InscricaoEstadual)
        {
            return unityOfWork
                .Query<Propriedade>()
                .FirstOrDefault(e => e.InscricaoEstadual == InscricaoEstadual);
        }

        public bool ValidaPorInscricaoEstadual(string InscricaoEstadual)
        {
            return unityOfWork
                .Query<Propriedade>()
                .Any(e => e.InscricaoEstadual == InscricaoEstadual);
        }

        public List<Propriedade> ObterTodos()
        {
            return unityOfWork
                .Query<Propriedade>()
                .ToList();
        }

        public List<Propriedade> ObterPorIdProdutor(int Id)
        {
            return unityOfWork
                .Query<Propriedade>()
                .Where(x => x.Produtor.IdProdutor == Id)
                .ToList();
        }
    }
}
