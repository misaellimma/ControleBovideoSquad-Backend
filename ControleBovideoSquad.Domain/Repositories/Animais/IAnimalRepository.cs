using ControleBovideoSquad.Domain.Entities.Animais;

namespace ControleBovideoSquad.Domain.Repositories.Animais
{
    public interface IAnimalRepository
    {
        Animal ObterPorId(int id);
        List<Animal> ObterTodos();
        List<Animal> ObterPorCpfProdutor(string cpfProdutor);
        List<Animal> ObterPorInscricaoPropriedade(string inscricaoEstadual);
        void Salvar(Animal animal);
    }
}
