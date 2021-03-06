using ControleBovideoSquad.Domain.Entities.Animais;
using ControleBovideoSquad.Domain.Repositories.Animais;
using ControleBovideoSquad.Repository.Interfaces;

namespace ControleBovideoSquad.Repository.Animais
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly IUnityOfWork _unitOfWork;

        public AnimalRepository(IUnityOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Animal> ObterTodos()
        {
            return _unitOfWork
                .Query<Animal>().Where(x => x.Ativo == true).OrderBy(x => x.PropriedadeAnimal.Nome).ToList();
        }

        public Animal ObterPorId(int id)
        {
            return _unitOfWork
                .Query<Animal>()
                .SingleOrDefault(x => x.IdAnimal == id);
        }

        public List<Animal> ObterPorCpfProdutor(string cpfProdutor)
        {
            throw new NotImplementedException();
        }

        public List<Animal> ObterPorInscricaoPropriedade(string inscricaoEstadual)
        {
            throw new NotImplementedException();
        }

        public void Salvar(Animal animal)
        {
            _unitOfWork.SaveOrUpdate(animal);
        }

    }
}
