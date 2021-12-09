using ControleBovideoSquad.Application.IServices.Vacinacao;
using ControleBovideoSquad.Domain.Entities.Vacinacao;
using ControleBovideoSquad.Domain.Repositories.Vacinacao;

namespace ControleBovideoSquad.Application.Services
{
    public class VacinaService : IVacinaService
    {
        private readonly IVacinaRepository vacinaRepository;

        public VacinaService(IVacinaRepository vacinaRepository)
        {
            this.vacinaRepository = vacinaRepository;
        }

        public Vacina ObterPorId(int id)
        {
            return vacinaRepository.ObterPorId(id);
        }

        public List<Vacina> ObterTodos()
        {
            return vacinaRepository.ObterTodos();
        }
    }
}
