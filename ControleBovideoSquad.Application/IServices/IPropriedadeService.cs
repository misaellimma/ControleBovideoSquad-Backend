using ControleBovideoSquad.CrossCutting.Dto.Propriedade;
using ControleBovideoSquad.CrossCutting.Util;
using ControleBovideoSquad.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.IServices
{
    public interface IPropriedadeService
    {
        List<PropriedadeDto> ObterTodos();
        List<PropriedadeDto> ObterPorIdProdutor(int id);
        Result<PropriedadeDto> ObterPorInscricaoEstadual(string InscricaoEstadual);
        Result<PropriedadeDto> ObterPorId(int id);
        Result<bool> Alterar(PropriedadeDto propriedadeDto);
        Result<PropriedadeDto> Incluir(PropriedadeDto propriedadeDto);
    }
}
