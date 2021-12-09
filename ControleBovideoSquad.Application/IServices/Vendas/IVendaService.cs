using ControleBovideoSquad.CrossCutting.Dto.Vendas;
using ControleBovideoSquad.CrossCutting.Util;
using ControleBovideoSquad.Domain.Entities.Vendas;

namespace ControleBovideoSquad.Application.IServices.Vendas
{
    public interface IVendaService
    {
        List<Venda> ObterTodos();
        Venda ObterPorId(int id);
        List<Venda> ObterPorCpfProdutor(string cpf);
        Result<Venda> Salvar(VendaDto vendaDto);
        Result<string> Cancelar(int id);
    }
}
