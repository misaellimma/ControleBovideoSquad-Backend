using ControleBovideoSquad.Domain.Entities.Enderecos;

namespace ControleBovideoSquad.Application.IServices.Enderecos
{
    public interface IMunicipioService
    {
        List<Municipio> ObterTodos();
        Municipio ObterPorId(int id);

    }
}
