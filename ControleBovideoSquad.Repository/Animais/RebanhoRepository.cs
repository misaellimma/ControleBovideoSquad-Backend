using ControleBovideoSquad.Domain.Entities.Animais;
using ControleBovideoSquad.Domain.Repositories.Animais;
using ControleBovideoSquad.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Repository.Animais
{
    public class RebanhoRepository : IRebanhoRepository
    {
        private readonly IUnityOfWork _unityOfWork;

        public RebanhoRepository(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public List<Rebanho> ObterRebanhos()
        {
            return _unityOfWork.Query<Rebanho>().ToList();
        }

        // TODO: implementar quando a classe de Propriedade estiver pronta.
        public List<Rebanho> ObterRebanhosPorPropriedade(string inscricaoEstadual)
        {
            return _unityOfWork.Query<Rebanho>().ToList();
        }

        public List<Rebanho> ObterRebannhosPorProdutor(string cpf)
        {
            return _unityOfWork.Query<Rebanho>().ToList();
        }
    }
}
