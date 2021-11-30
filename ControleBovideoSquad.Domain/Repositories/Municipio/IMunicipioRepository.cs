using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleBovideoSquad.Domain.Entities.Municipios;

namespace ControleBovideoSquad.Domain.Repositories.Municipios
{
    public interface IMunicipioRepository
    {
        List<Municipio> ObterTodos();
        Municipio ObterPorId(int id);
    }
}
