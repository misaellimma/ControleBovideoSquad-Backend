using ControleBovideoSquad.CrossCutting.Dto.Produtores;
using ControleBovideoSquad.CrossCutting.Util;

namespace ControleBovideoSquad.Application.IServices.Produtores
{
    public interface IProdutorService
    {
        List<ProdutorDto> ObterTodos();
        Result<ProdutorDto> ObterProdutorPorCpf(string cpf);
        Result<ProdutorDto> ObterProdutorPorId(int id);
        Result<ProdutorDto> CriarProdutor(ProdutorDto produtor);
        Result<bool> AlterarProdutor(int id, ProdutorDto produtor);
    }
}
