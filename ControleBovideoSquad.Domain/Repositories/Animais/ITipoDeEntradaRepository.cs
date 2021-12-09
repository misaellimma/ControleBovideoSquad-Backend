using ControleBovideoSquad.Domain.Entities.Animais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Domain.Repositories.Animais
{
    public interface ITipoDeEntradaRepository
    {
        TipoDeEntrada ObterPorId(int id);
        List<TipoDeEntrada> ObterTodos();
    }
}
