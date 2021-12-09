using ControleBovideoSquad.Domain.Entities.Animais;
using ControleBovideoSquad.Domain.Repositories.Animais;
using ControleBovideoSquad.Repository.Interfaces;

namespace ControleBovideoSquad.Repository.Animais
{
    public class RebanhoRepository : IRebanhoRepository
    {
        private readonly IUnityOfWork _unityOfWork;

        public RebanhoRepository(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public List<Rebanho> ObterTodos()
        {
            return _unityOfWork.Query<Rebanho>().OrderBy(x => x.Propriedade.Nome).ToList();
        }

        // TODO: implementar quando a classe de Propriedade estiver pronta.
        public List<Rebanho> ObterPorInscricaoPropriedade(string inscricaoEstadual)
        {
            return _unityOfWork.Query<Rebanho>().Where(x => x.Propriedade.InscricaoEstadual == inscricaoEstadual).ToList();
        }

        public Rebanho ObterPorPropriedadeEEspecie(string inscricaoEstadual, int idEspecie)
        {
            var rebanho = _unityOfWork.Query<Rebanho>().Where(
                x => x.Propriedade.InscricaoEstadual == inscricaoEstadual && x.Especie.IdEspecie == idEspecie
                ).FirstOrDefault();

            return rebanho;
        }

        public List<Rebanho> ObterPorCpfProdutor(string cpf)
        {
            return _unityOfWork.Query<Rebanho>().Where(x => x.Propriedade.Produtor.CPF == cpf).ToList();
        }

        public Rebanho ObterPorId(int id)
        {
            return _unityOfWork.Query<Rebanho>().FirstOrDefault(x => x.IdRebanho == id);
        }

        public void Salvar(Rebanho rebanho)
        {
            this._unityOfWork.SaveOrUpdate(rebanho);
        }
    }
}
