using ControleBovideoSquad.CrossCutting.Dto.AnimaisDto;
using ControleBovideoSquad.CrossCutting.Util;
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
        AnimalDto ObterPorId(int id);
        List<Animal> ObterPorProdutor(string cpf);
        List<Animal> ObterPorPropriedade(string inscricaoEstadual);
        Result<Animal> SalvarAnimal(AnimalDto animal);
        string CancelarAnimal(int id);
    }
}
