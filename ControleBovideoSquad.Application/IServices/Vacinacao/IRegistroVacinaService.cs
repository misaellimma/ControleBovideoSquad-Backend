using ControleBovideoSquad.CrossCutting.Dto.Vacinacao;
using ControleBovideoSquad.CrossCutting.Util;
using ControleBovideoSquad.Domain.Entities.Vacinacao;

namespace ControleBovideoSquad.Application.IServices.Vacinacao
{
    public interface IRegistroVacinaService
    {
        Result<string> Cancelar(int id);
        Result<RegistroVacina> Incluir(RegistroVacinaDto registroVacina);
        List<RegistroVacinaDto> ObterPorPropriedade(string inscricaoEstadual); 
    }
}
