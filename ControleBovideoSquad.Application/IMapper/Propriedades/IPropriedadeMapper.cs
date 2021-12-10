using ControleBovideoSquad.CrossCutting.Dto.Propriedades;
using ControleBovideoSquad.Domain.Entities.Propriedades;

namespace ControleBovideoSquad.Application.IMapper.Propriedades
{
    public interface IPropriedadeMapper : IMapper<PropriedadeDto, Propriedade>
    {
        List<PropriedadeDto> MapearEntidadeParaDto(List<Propriedade> produtores);

    }
}
