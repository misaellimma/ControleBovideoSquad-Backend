using ControleBovideoSquad.CrossCutting.Dto.AnimaisDto;
using ControleBovideoSquad.Domain.Entities.Animais;

namespace ControleBovideoSquad.Application.IMapper.Animais
{
    public interface IRebanhoMapper : IMapper<RebanhoDto, Rebanho>
    {
        Rebanho MapearDtoParaEntidade(RebanhoDto rebanhoDto);
    }
}