using ControleBovideoSquad.Domain.Entities.Animais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Domain.Repositories.Animais
{
    public interface IAnimalRepository
    {
        Animal ObterAnimalPorId(int id);
        List<Animal> ObterTodos();
        List<Animal> ObterAnimalPorProdutor(string cpfProdutor);
        List<Animal> ObterAnimalPorPropriedade(string inscricaoEstadual);
        void Salvar(Animal animal);
        void Cancelar(int idAnimal);
    }
}
