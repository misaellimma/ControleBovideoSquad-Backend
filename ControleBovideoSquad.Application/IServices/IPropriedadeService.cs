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
        Result<PropriedadeDto> Alterar(int id, PropriedadeDto propriedadeDto);
        Result<PropriedadeDto> Criar(PropriedadeDto propriedadeDto);
    }
}
