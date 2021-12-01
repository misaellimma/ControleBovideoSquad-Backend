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
        private readonly IUnityOfWork _unityOfWork;

        public PropriedadeRepository(IUnityOfWork unityOfWork)
        {
            this._unityOfWork = unityOfWork;
        
        }

        public void CriarOuAlterar(Domain.Entities.Propriedade produtor)
        {
            throw new NotImplementedException();
        }

        public Propriedade ObterPorId(int id)
        {
            return _unityOfWork.Query<Propriedade>().FirstOrDefault(x => x.IdPropriedade == id);
        }

        public Propriedade ObterPorInscricaoEstadual(string InscricaoEstadual)
        {
            throw new NotImplementedException();
        }

        public List<Propriedade> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
