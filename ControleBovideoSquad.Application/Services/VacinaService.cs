using ControleBovideoSquad.Application.IServices;
using ControleBovideoSquad.Domain.Entities.Vacinas;
using ControleBovideoSquad.Domain.Repositories.Vacinas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
