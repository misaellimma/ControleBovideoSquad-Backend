using ControleBovideoSquad.CrossCutting.Dto.Animais;
using ControleBovideoSquad.CrossCutting.Util;
using ControleBovideoSquad.Domain.Entities.Animais;

namespace ControleBovideoSquad.Application.IServices.Animais
{
    public interface IAnimalService
    {
        List<Animal> ObterTodos();
        AnimalDto ObterPorId(int id);
        List<Animal> ObterPorCpfProdutor(string cpf);
        List<Animal> ObterPorInscricaoPropriedade(string inscricaoEstadual);
        Result<Animal> Salvar(AnimalDto animal);
        string Cancelar(int id);
    }
}
