using ControleBovideoSquad.Domain.Entities.Municipio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.IServices
{
    public interface IMunicipio
    {
        List<Municipio> getAll();
    }
}
