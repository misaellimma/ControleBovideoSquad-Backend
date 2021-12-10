using ControleBovideoSquad.Domain.Entities.Animais;

namespace ControleBovideoSquad.Domain.Repositories.Animais
{
    public interface ITipoDeEntradaRepository
    {
        TipoDeEntrada ObterPorId(int id);
        List<TipoDeEntrada> ObterTodos();
    }
}
