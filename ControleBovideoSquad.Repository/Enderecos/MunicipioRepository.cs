using ControleBovideoSquad.Domain.Entities.Municipios;
using ControleBovideoSquad.Domain.Repositories.Municipios;
using ControleBovideoSquad.Repository.Interfaces;
using ControleBovideoSquad.Repository.Util;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Repository.Enderecos
{
    public class MunicipioRepository : IMunicipioRepository
    {
        private readonly IUnityOfWork unityOfWork;

        public MunicipioRepository(IUnityOfWork unityOfWork)
        {
            this.unityOfWork = unityOfWork;
        }

        public Municipio ObterPorId(int id)
        {
            return unityOfWork
                .Query<Municipio>()
                .SingleOrDefault(e => e.IdMunicipio == id);
        }

        public List<Municipio> ObterTodos()
        {
            return unityOfWork
                .Query<Municipio>()
                .ToList();
        }
    }
}
