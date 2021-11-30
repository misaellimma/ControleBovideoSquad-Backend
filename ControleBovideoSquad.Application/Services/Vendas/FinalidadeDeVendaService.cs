using ControleBovideoSquad.Application.IServices;
using ControleBovideoSquad.Domain.Entities.Vendas;
using ControleBovideoSquad.Domain.Repositories.Vendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.Services
{
    public class FinalidadeDeVendaService : IFinalidadeDeVendaService
    {
        private readonly IFinalidadeDeVendaRepository _finalidadeDeVendaRepository;

        public FinalidadeDeVendaService(IFinalidadeDeVendaRepository finalidadeDeVendaRepository)
        {
            this._finalidadeDeVendaRepository = finalidadeDeVendaRepository;
        }

        public FinalidadeDeVenda? Obter(int id)
        {
            return _finalidadeDeVendaRepository.ObterPorId(id);
        }

        public List<FinalidadeDeVenda> ObterTodos()
        {
            return _finalidadeDeVendaRepository.ObterTodos();
        }
    }
}
