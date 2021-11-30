using ControleBovideoSquad.Domain.Entities.Animais;

namespace ControleBovideoSquad.Domain.Repositories.Animais
{
    public interface IRebanhoRepository
    {
        List<Rebanho> ObterRebanhos();
        List<Rebanho> ObterRebanhosPorPropriedade(string inscricaoEstadual);
        List<Rebanho> ObterRebannhosPorProdutor(string cpf);
    }
}
