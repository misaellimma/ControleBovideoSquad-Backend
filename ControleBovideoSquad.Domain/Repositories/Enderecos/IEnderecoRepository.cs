using ControleBovideoSquad.Domain.Entities.Enderecos;

namespace ControleBovideoSquad.Domain.Repositories.Enderecos
{
    public interface IEnderecoRepository
    {
        Endereco ObterEnderecoPorID(int id);
        List<Endereco> ObterEnderecos();
        void Save(Endereco endereco);        
    }
}
