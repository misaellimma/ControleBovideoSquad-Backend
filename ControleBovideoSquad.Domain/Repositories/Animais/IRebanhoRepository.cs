using ControleBovideoSquad.Domain.Entities.Animais;

namespace ControleBovideoSquad.Domain.Repositories.Animais
{
    public interface IRebanhoRepository
    {
        List<Rebanho> ObterRebanhos();
        List<Rebanho> ObterRebanhosPorPropriedade(string inscricaoEstadual);
        List<Rebanho> ObterRebanhosPorProdutor(string cpf);
        Rebanho ObterRebanhosPorId(int id);
    }
}
