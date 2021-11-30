using ControleBovideoSquad.CrossCutting.Dto.Municipio;
using ControleBovideoSquad.Domain.Entities.Municipios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.IServices
{
    public interface IMunicipioService
    {
        List<Municipio> ObterTodos();
        Municipio ObterPorId(int id);

    }
}
