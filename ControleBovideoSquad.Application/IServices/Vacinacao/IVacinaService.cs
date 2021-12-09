using ControleBovideoSquad.Domain.Entities.Vacinacao;

namespace ControleBovideoSquad.Application.IServices.Vacinacao
{
    public interface IVacinaService
    {
        Vacina ObterPorId(int id);
        List<Vacina> ObterTodos();
    }
}
