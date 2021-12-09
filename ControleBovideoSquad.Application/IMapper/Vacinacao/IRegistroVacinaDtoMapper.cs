using ControleBovideoSquad.CrossCutting.Dto.Vacinacao;
using ControleBovideoSquad.Domain.Entities.Vacinacao;

namespace ControleBovideoSquad.Application.IMapper.RegistroVacinas
{
    public interface IRegistroVacinaDtoMapper : IMapper<RegistroVacinaDto, RegistroVacina>
    {
        List<RegistroVacinaDto> MapearListaParaEntidadeDto(List<RegistroVacina> registroVacinaList);
    }
}
