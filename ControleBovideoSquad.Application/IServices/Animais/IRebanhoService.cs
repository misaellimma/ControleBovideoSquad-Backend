using ControleBovideoSquad.CrossCutting.Dto.AnimaisDto;
using ControleBovideoSquad.CrossCutting.Util;
using ControleBovideoSquad.Domain.Entities.Animais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.IServices.Animais
{
    public interface IRebanhoService
    {
        List<RebanhoDto> ObterRebanhos();
        List<RebanhoDto> ObterRebanhosPorPropriedade(string inscricaoEstadual);
        Rebanho ObterRebanhoPorPropriedadeEEspecie(string inscricaoEstadual, int idEspecie);
        List<RebanhoDto> ObterRebanhosPorProdutor(string cpf);
        Rebanho ObterRebanhoPorId(int id);
        Result<Rebanho> SalvarRebanho(RebanhoDto rebanhoDto);
    }
}
