using ControleBovideoSquad.CrossCutting.Dto.Produtores;
using ControleBovideoSquad.Domain.Entities.Produtores;

namespace ControleBovideoSquad.Application.IMapper.Produtores
{
    public interface IProdutorMapper : IMapper<ProdutorDto, Produtor>
    {
        List<ProdutorDto> MapearEntidadeParaDto(List<Produtor> produtores);
    }
}
