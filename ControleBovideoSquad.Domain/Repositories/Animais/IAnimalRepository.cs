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
        Animal ObterPorId(int id);
        List<Animal> ObterTodos();
        List<Animal> ObterPorCpfProdutor(string cpfProdutor);
        List<Animal> ObterPorInscricaoPropriedade(string inscricaoEstadual);
        void Salvar(Animal animal);
    }
}
