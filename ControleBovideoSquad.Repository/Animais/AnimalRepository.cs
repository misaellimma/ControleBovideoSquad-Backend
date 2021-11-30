using ControleBovideoSquad.Domain.Entities.Animal;
using ControleBovideoSquad.Domain.Repositories.Animais;
using ControleBovideoSquad.Repository.Util;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Repository.Animais
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly ISession _session;

        public AnimalRepository(SessionFactory session)
        {
            _session = session;
        }
        public void Cancelar(int idAnimal)
        {
            throw new NotImplementedException();
        }

        public Animal ObterAnimalPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Animal> ObterAnimalPorProdutor(string cpfProdutor)
        {
            throw new NotImplementedException();
        }

        public List<Animal> ObterAnimalPorPropriedade(string inscricaoEstadual)
        {
            throw new NotImplementedException();
        }

        public void Salvar(Animal animal)
        {
            throw new NotImplementedException();
        }

    }
}
