using ControleBovideoSquad.CrossCutting.Dto.Animais;
using ControleBovideoSquad.CrossCutting.Util;
using ControleBovideoSquad.Domain.Entities.Animais;

namespace ControleBovideoSquad.Application.IServices.Animais
{
    public interface IRebanhoService
    {
        List<RebanhoDto> ObterTodos();
        List<RebanhoDto> ObterPorInscricaoPropriedade(string inscricaoEstadual);
        Rebanho ObterPorPropriedadeEEspecie(string inscricaoEstadual, int idEspecie);
        List<RebanhoDto> ObterPorCpfProdutor(string cpf);
        Rebanho ObterPorId(int id);
        Result<Rebanho> Salvar(RebanhoDto rebanhoDto);
    }
}
