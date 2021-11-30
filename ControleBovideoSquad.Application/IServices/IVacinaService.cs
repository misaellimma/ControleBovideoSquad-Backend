using ControleBovideoSquad.Domain.Entities.Vacinas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.IServices
{
    public interface IVacinaService
    {
        Vacina ObterPorId(int id);
        List<Vacina> ObterTodos();
    }
}
