using ControleBovideoSquad.Domain.Entities;
using ControleBovideoSquad.Domain.Repositories.Animais;
using ControleBovideoSquad.Repository.Interface;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Repository.Animais
{
    public class EspecieRepository : IEspecieRepository
    {
        private readonly ISession _session;

        public EspecieRepository(IUnitOfWork sessionFactory)
        {
            _session = sessionFactory.OpenSession();
        }

        public Especie ObterEspeciePorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Especie> ObterEspecies()
        {
            return _session.Query<Especie>().ToList();
        }
    }
}
