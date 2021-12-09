using ControleBovideoSquad.Application.IServices.Vendas;
using ControleBovideoSquad.Domain.Entities.Vendas;
using ControleBovideoSquad.Domain.Repositories.Vendas;

namespace ControleBovideoSquad.Application.Services.Vendas
{
    public class FinalidadeDeVendaService : IFinalidadeDeVendaService
    {
        private readonly IFinalidadeDeVendaRepository _finalidadeDeVendaRepository;

        public FinalidadeDeVendaService(IFinalidadeDeVendaRepository finalidadeDeVendaRepository)
        {
            _finalidadeDeVendaRepository = finalidadeDeVendaRepository;
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
