using ControleBovideoSquad.Domain.Entities.Produtores;

namespace ControleBovideoSquad.Domain.Repositories.Produtores
{
    public interface IProdutorRepository
    {
        List<Produtor> ObterTodos();
        Produtor ObterProdutorPorCpf(string cpf);
        Produtor ObterProdutorPorId(int id);
        void Salvar(Produtor produtor);
    }
}
