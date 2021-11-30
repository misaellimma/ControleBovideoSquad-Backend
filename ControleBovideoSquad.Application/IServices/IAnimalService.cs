using ControleBovideoSquad.Domain.Entities.Animal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.IServices
{
    public interface IAnimalService
    {
        List<Animal> ObterTodos();
        Animal ObterPorId(int id);
        List<Animal> ObterPorProdutor(string cpf);
        List<Animal> ObterPorPropriedade(string inscricaoEstadual);
    }
}
