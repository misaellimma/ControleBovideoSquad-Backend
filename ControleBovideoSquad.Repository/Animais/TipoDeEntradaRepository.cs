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
    internal class TipoDeEntradaRepository : ITipoDeEntradaRepository
    {
        private readonly IUnityOfWork _unityOfWork;
        public TipoDeEntradaRepository(IUnityOfWork unityOfWork)
        {
            this._unityOfWork = unityOfWork;
        }
        public TipoDeEntrada ObterTipoDeEntradaPorId(int id)
        {
            return this._unityOfWork
                .Query<TipoDeEntrada>()
                .SingleOrDefault(x => x.IdTipoDeEntrada == id);
        }

        public List<TipoDeEntrada> ObterTipos()
        {
            return this._unityOfWork
                .Query<TipoDeEntrada>()
                .ToList();
        }
    }
}
