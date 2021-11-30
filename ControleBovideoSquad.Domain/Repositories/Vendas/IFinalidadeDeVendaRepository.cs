using ControleBovideoSquad.Domain.Entities.Vendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Domain.Repositories.Vendas
{
    public interface IFinalidadeDeVendaRepository
    {
        List<FinalidadeDeVenda> ObterTodos();
        FinalidadeDeVenda? ObterPorId(int id);        
    }
}
