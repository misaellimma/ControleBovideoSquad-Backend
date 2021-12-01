using ControleBovideoSquad.CrossCutting.Dto.AnimaisDto;
using ControleBovideoSquad.Domain.Entities.Animais;

namespace ControleBovideoSquad.Application.IMapper.Animais
{
    public interface IAnimalMapper : IMapper<AnimalDto, Animal>
    {
        Animal MapearDtoParaEntidade(AnimalDto animalDto);
    }
}