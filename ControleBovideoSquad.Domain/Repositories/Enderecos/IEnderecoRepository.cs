using ControleBovideoSquad.Domain.Entities.Enderecos;

namespace ControleBovideoSquad.Domain.Repositories.Enderecos
{
    public interface IEnderecoRepository
    {
        Endereco ObterPorID(int id);
        List<Endereco> ObterTodos();
        void Salvar(Endereco endereco);        
    }
}
