using ControleBovideoSquad.CrossCutting.Dto.RegistroVacina;
using ControleBovideoSquad.CrossCutting.Util;
using ControleBovideoSquad.Domain.Entities.Animal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.IServices
{
    public interface IRegistroVacinaService
    {
        Result<string> Cancelar(int id);
        Result<RegistroVacina> Incluir(RegistroVacinaDto registroVacina);
        List<RegistroVacina> ObterPorPropriedade(string inscricaoEstadual); 
    }
}
