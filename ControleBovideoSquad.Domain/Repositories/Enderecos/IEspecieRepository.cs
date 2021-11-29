using ControleBovideoSquad.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Domain.Repositories.Enderecos
{
    public interface IEspecieRepository
    {
        Especie ObterEspeciePorId(int id);
        List<Especie> ObterEspecies();
    }
}
