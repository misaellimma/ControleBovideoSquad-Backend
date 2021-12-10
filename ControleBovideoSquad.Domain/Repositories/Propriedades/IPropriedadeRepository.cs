using ControleBovideoSquad.Domain.Entities.Propriedades;

namespace ControleBovideoSquad.Domain.Repositories.Propriedades
{
    public interface IPropriedadeRepository
    {
        List<Propriedade> ObterTodos();
        List<Propriedade> ObterPorIdProdutor(int id);
        Propriedade ObterPorInscricaoEstadual(string InscricaoEstadual);
        bool ValidaPorInscricaoEstadual(string InscricaoEstadual);
        Propriedade ObterPorId(int id);
        void Salvar(Propriedade produtor);
    }
}
