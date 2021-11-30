using ControleBovideoSquad.Domain.Entities.Vendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.IServices
{
    public interface IFinalidadeDeVendaService
    {
        List<FinalidadeDeVenda> ObterTodos();
        FinalidadeDeVenda? Obter(int id);
    }
}
