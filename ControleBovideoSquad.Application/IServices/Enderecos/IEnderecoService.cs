using ControleBovideoSquad.CrossCutting.Dto.Enderecos;
using ControleBovideoSquad.CrossCutting.Util;
using ControleBovideoSquad.Domain.Entities.Enderecos;

namespace ControleBovideoSquad.Application.IServices.Enderecos
{
    public interface IEnderecoService
    {
        Result<Endereco> Save(EnderecoDto endereco);
        List<Endereco> ObterTodos();
        Endereco Obter(int id);
    }
}
