using ControleBovideoSquad.Domain.Entities.Animais;
using ControleBovideoSquad.Domain.Repositories.Animais;
using ControleBovideoSquad.Repository.Interfaces;
using NHibernate;

namespace ControleBovideoSquad.Repository.Animais
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly IUnityOfWork _unitOfWork;

        public AnimalRepository(IUnityOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Cancelar(int idAnimal)
        {
            throw new NotImplementedException();
        }

        public List<Animal> ObterTodos()
        {
            return _unitOfWork
                .Query<Animal>().ToList();
        }

        public Animal ObterAnimalPorId(int id)
        {
            return _unitOfWork
                .Query<Animal>()
                .SingleOrDefault(x => x.IdAnimal == id);
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
            _unitOfWork.SaveOrUpdate(animal);
        }

    }
}
