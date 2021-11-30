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
            var vacina = vacinaRepository.ObterPorId(id);
            return vacina;
        }

        public List<Vacina> ObterTodos()
        {
            var vacinas = vacinaRepository.ObterTodos();
            return vacinas;
        }
    }
}
