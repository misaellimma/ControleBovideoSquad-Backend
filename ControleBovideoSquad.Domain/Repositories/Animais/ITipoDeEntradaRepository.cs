using ControleBovideoSquad.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Domain.Repositories.Animais
{
    public interface ITipoDeEntradaRepository
    {
        TipoDeEntrada ObterTipoDeEntradaPorId(int id);
        List<TipoDeEntrada> ObterTipos();
    }
}
