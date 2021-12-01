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
        Result<PropriedadeDto> ObterPorInscricaoEstadual(string InscricaoEstadual);
        Result<PropriedadeDto> ObterPorId(int id);
        void Alterar(Propriedade produtor);
        void Criar(Propriedade produtor);
    }
}
