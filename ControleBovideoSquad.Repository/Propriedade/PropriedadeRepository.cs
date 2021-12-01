using ControleBovideoSquad.Domain.Repositories.Propriedades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Repository.Propriedade
{
    public class PropriedadeRepository : IPropriedadeRepository
    {
        public void CriarOuAlterar(Domain.Entities.Propriedade produtor)
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.Propriedade ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.Propriedade ObterPorInscricaoEstadual(string InscricaoEstadual)
        {
            throw new NotImplementedException();
        }

        public List<Domain.Entities.Propriedade> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
