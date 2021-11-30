using ControleBovideoSquad.Application.IServices.Vendas;
using ControleBovideoSquad.Domain.Entities.Vendas;
using ControleBovideoSquad.Domain.Repositories.Vendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.Services.Vendas
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;

        public VendaService(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public Venda ObterVendaPorId(int id)
        {
            return _vendaRepository.ObterVendaPorId(id);
        }

        public List<Venda> ObterVendaPorProdutor(string cpf)
        {
            return _vendaRepository.ObterVendaPorProdutor(cpf);
        }

        public List<Venda> ObterVendas()
        {
            return _vendaRepository.ObterVendas();
        }
    }
}
