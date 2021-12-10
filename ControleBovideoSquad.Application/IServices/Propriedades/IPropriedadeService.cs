using ControleBovideoSquad.CrossCutting.Dto.Propriedades;
using ControleBovideoSquad.CrossCutting.Util;

namespace ControleBovideoSquad.Application.IServices.Propriedades
{
    public interface IPropriedadeService
    {
        List<PropriedadeDto> ObterTodos();
        List<PropriedadeDto> ObterPorIdProdutor(int id);
        Result<PropriedadeDto> ObterPorInscricaoEstadual(string InscricaoEstadual);
        Result<bool> ValidaPorInscricaoEstadual(string InscricaoEstadual);
        Result<PropriedadeDto> ObterPorId(int id);
        Result<bool> Alterar(PropriedadeDto propriedadeDto);
        Result<PropriedadeDto> Incluir(PropriedadeDto propriedadeDto);
    }
}
