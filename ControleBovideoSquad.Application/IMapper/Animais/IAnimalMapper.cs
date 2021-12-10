using ControleBovideoSquad.CrossCutting.Dto.Animais;
using ControleBovideoSquad.Domain.Entities.Animais;

namespace ControleBovideoSquad.Application.IMapper.Animais
{
    public interface IAnimalMapper : IMapper<AnimalDto, Animal>
    {    
    }
}