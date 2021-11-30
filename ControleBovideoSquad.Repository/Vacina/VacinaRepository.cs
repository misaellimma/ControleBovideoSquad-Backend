using ControleBovideoSquad.Domain.Entities.Vacinas;
using ControleBovideoSquad.Domain.Repositories.Vacinas;
using ControleBovideoSquad.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Repository.Vacinas
{
    public class VacinaRepository : IVacinaRepository
    {
        private readonly IUnityOfWork unityOfWork;

        public VacinaRepository(IUnityOfWork unityOfWork)
        {
            this.unityOfWork = unityOfWork;
        }

        public Vacina ObterPorId(int id)
        {
            return unityOfWork
                .Query<Vacina>()
                .FirstOrDefault(e => e.IdVacina == id);
        }

        public List<Vacina> ObterTodos()
        {
            return unityOfWork
                .Query<Vacina>()
                .ToList();
        }
    }
}
