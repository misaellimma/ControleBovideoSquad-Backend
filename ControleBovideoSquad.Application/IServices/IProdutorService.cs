using ControleBovideoSquad.CrossCutting.Dto.Produtor;
using ControleBovideoSquad.CrossCutting.Util;

namespace ControleBovideoSquad.Application.IServices
{
    public interface IProdutorService
    {
        List<ProdutorDto> ObterTodos();
        Result<ProdutorDto> ObterProdutorPorCpf(string cpf);
        Result<ProdutorDto> ObterProdutorPorId(int id);
        Result<ProdutorDto> Incluir(ProdutorDto produtor);
        Result<bool> Alterar(int id, ProdutorDto produtor);
    }
}
