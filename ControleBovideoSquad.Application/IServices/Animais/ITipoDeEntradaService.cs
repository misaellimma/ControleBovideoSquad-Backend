using ControleBovideoSquad.Domain.Entities.Animais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.IServices.Animais
{
    public interface ITipoDeEntradaService
    {
        List<TipoDeEntrada> ObterTodos();
        TipoDeEntrada ObterPorId(int id);
    }
}
