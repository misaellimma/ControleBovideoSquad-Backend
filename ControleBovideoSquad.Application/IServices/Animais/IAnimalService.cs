using ControleBovideoSquad.Domain.Entities.Animais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.IServices.Animais
{
    public interface IAnimalService
    {
        List<Animal> ObterTodos();
        Animal ObterPorId(int id);
        List<Animal> ObterPorProdutor(string cpf);
        List<Animal> ObterPorPropriedade(string inscricaoEstadual);
    }
}
