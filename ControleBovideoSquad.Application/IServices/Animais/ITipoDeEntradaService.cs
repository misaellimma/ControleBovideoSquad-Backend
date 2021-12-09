using ControleBovideoSquad.Domain.Entities.Animais;

namespace ControleBovideoSquad.Application.IServices.Animais
{
    public interface ITipoDeEntradaService
    {
        List<TipoDeEntrada> ObterTodos();
        TipoDeEntrada ObterPorId(int id);
    }
}
