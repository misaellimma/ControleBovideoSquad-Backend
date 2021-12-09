using ControleBovideoSquad.Domain.Entities.Animais;

namespace ControleBovideoSquad.Application.IServices.Animais
{
    public interface IEspecieService
    {
        Especie? ObterPorId(int id);
        List<Especie> ObterTodos();
    }
}
