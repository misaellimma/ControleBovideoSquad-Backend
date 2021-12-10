using ControleBovideoSquad.Domain.Entities.Animais;

namespace ControleBovideoSquad.Domain.Repositories.Animais
{
    public interface IEspecieRepository
    {
        Especie ObterPorId(int id);
        List<Especie> ObterTodos();
    }
}
