using ControleBovideoSquad.CrossCutting.Dto.Propriedades;
using ControleBovideoSquad.CrossCutting.Util;

namespace ControleBovideoSquad.Application.IServices.Propriedades
{
    public interface IPropriedadeService
    {
        List<PropriedadeDto> ObterTodos();
        List<PropriedadeDto> ObterPorIdProdutor(int id);
        Result<PropriedadeDto> ObterPorInscricaoEstadual(string InscricaoEstadual);
        Result<PropriedadeDto> ObterPorId(int id);
        Result<PropriedadeDto> Alterar(PropriedadeDto propriedadeDto);
        Result<PropriedadeDto> Criar(PropriedadeDto propriedadeDto);
    }
}
