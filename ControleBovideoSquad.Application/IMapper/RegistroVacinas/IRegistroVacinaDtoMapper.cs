using ControleBovideoSquad.CrossCutting.Dto.RegistroVacina;
using ControleBovideoSquad.Domain.Entities.Animal;

namespace ControleBovideoSquad.Application.IMapper.RegistroVacinas
{
    public interface IRegistroVacinaDtoMapper : IMapper<RegistroVacinaDto, RegistroVacina>
    {
        List<RegistroVacinaDto> MapearListaParaEntidadeDto(List<RegistroVacina> registroVacinaList);
    }
}
