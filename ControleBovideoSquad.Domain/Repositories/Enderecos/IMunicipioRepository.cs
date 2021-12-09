using ControleBovideoSquad.Domain.Entities.Enderecos;

namespace ControleBovideoSquad.Domain.Repositories.Enderecos
{
    public interface IMunicipioRepository
    {
        List<Municipio> ObterTodos();
        Municipio ObterPorId(int id);
    }
}
