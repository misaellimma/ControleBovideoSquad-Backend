using ControleBovideoSquad.Domain.Entities.Vendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Domain.Repositories.Vendas
{
    public interface IVendaRepository
    {
        List<Venda> ObterVendas();
        Venda ObterVendaPorId(int id);
        List<Venda> ObterVendaPorProdutor(string cpf);
    }
}
