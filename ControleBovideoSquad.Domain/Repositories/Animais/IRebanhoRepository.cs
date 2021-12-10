using ControleBovideoSquad.Domain.Entities.Animais;

namespace ControleBovideoSquad.Domain.Repositories.Animais
{
    public interface IRebanhoRepository
    {
        List<Rebanho> ObterTodos();
        List<Rebanho> ObterPorInscricaoPropriedade(string inscricaoEstadual);
        List<Rebanho> ObterPorCpfProdutor(string cpf);
        Rebanho ObterPorId(int id);
        void Salvar(Rebanho rebanho);
        Rebanho ObterPorPropriedadeEEspecie(string ie, int idEspecie);
    }
}
