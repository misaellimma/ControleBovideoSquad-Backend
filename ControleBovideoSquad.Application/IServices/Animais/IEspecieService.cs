using ControleBovideoSquad.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.IServices.Animais
{
    public interface IEspecieService
    {
        Especie? ObterPorId(int id);
        List<Especie> ObterTodos();
    }
}
