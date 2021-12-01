using ControleBovideoSquad.Domain.Entities;
using ControleBovideoSquad.Domain.Repositories.Propriedades;
using ControleBovideoSquad.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Repository.Propriedades
{
    public class PropriedadeRepository : IPropriedadeRepository
    {
        private readonly IUnityOfWork unityOfWork;

        public PropriedadeRepository(IUnityOfWork unityOfWork)
        {
            this.unityOfWork = unityOfWork;
        
        }

        public void CriarOuAlterar(Domain.Entities.Propriedade produtor)
        {
            throw new NotImplementedException();
        }

        public Propriedade ObterPorId(int id)
        {
            return unityOfWork
                .Query<Propriedade>()
                .FirstOrDefault(e => e.IdPropriedade == id);
        }

        public Propriedade ObterPorInscricaoEstadual(string InscricaoEstadual)
        {
            return unityOfWork
                .Query<Propriedade>()
                .FirstOrDefault(e => e.InscricaoEstadual == InscricaoEstadual);
        }

        public List<Propriedade> ObterTodos()
        {
            return unityOfWork
                .Query<Propriedade>()
                .ToList();
        }
    }
}
