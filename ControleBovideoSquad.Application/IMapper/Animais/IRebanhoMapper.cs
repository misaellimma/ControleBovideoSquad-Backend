using ControleBovideoSquad.CrossCutting.Dto.Animais;
using ControleBovideoSquad.Domain.Entities.Animais;

namespace ControleBovideoSquad.Application.IMapper.Animais
{
    public interface IRebanhoMapper : IMapper<RebanhoDto, Rebanho>
    {        
        List<RebanhoDto> MaperListaEntidadeParaDto(List<Rebanho> rebanho);
    }
}