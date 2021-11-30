using ControleBovideoSquad.Application.IServices.Animais;
using ControleBovideoSquad.Domain.Entities.Animais;
using ControleBovideoSquad.Domain.Repositories.Animais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.Services.Animais
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalService(IAnimalRepository animalRepository)
        {
            this._animalRepository = animalRepository;
        }

        public Animal ObterPorId(int id)
        {
            var animal = _animalRepository.ObterAnimalPorId(id);
            return animal;
        }

        public List<Animal> ObterPorProdutor(string cpf)
        {
            var animal = _animalRepository.ObterAnimalPorProdutor(cpf);
            return animal;
        }

        public List<Animal> ObterPorPropriedade(string inscricaoEstadual)
        {
            var animal = _animalRepository.ObterAnimalPorPropriedade(inscricaoEstadual);
            return animal;
        }

        public List<Animal> ObterTodos()
        {
            var animais = _animalRepository.ObterTodos();
            return animais;
        }
    }
}
