using ControleBovideoSquad.Domain.Entities.Vacinacao;

namespace ControleBovideoSquad.Domain.Repositories.Vacinacao
{
    public interface IVacinaRepository
    {
        Vacina ObterPorId(int id);
        List<Vacina> ObterTodos();
    }
}
