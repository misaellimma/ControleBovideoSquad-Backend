using ControleBovideoSquad.Domain.Entities.Vacinacao;
using ControleBovideoSquad.Domain.Repositories.Vacinacao;
using ControleBovideoSquad.Repository.Interfaces;

namespace ControleBovideoSquad.Repository.Vacinacao
{
    public class RegistroVacinaRepository : IRegistroVacinaRepository
    {
        private readonly IUnityOfWork _unityOfWork;

        public RegistroVacinaRepository(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public RegistroVacina? ObterPorId(int id)
        {
            return _unityOfWork.Query<RegistroVacina>().FirstOrDefault(x => x.IdRegistroVacina == id);
        }

        public List<RegistroVacina> ObterPorInscricaoPropriedade(string inscricaoEstadual)
        {            
            return _unityOfWork.Query<RegistroVacina>().Where(x => x.Rebanho.Propriedade.InscricaoEstadual == inscricaoEstadual && x.Ativo == true).ToList();
        }

        public void Salvar(RegistroVacina registroVacina)
        {
            _unityOfWork.SaveOrUpdate(registroVacina);
        }
    }
}
