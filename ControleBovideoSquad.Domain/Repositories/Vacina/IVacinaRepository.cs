using ControleBovideoSquad.Domain.Entities.Vacinas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Domain.Repositories.Vacinas
{
    public interface IVacinaRepository
    {
        Vacina ObterPorId(int id);
        List<Vacina> ObterTodos();
    }
}
