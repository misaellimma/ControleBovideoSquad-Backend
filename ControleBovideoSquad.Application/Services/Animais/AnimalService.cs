﻿using ControleBovideoSquad.Application.IMapper.Animais;
using ControleBovideoSquad.Application.IServices.Animais;
using ControleBovideoSquad.CrossCutting;
using ControleBovideoSquad.CrossCutting.Dto.AnimaisDto;
using ControleBovideoSquad.CrossCutting.Util;
using ControleBovideoSquad.Domain.Entities;
using ControleBovideoSquad.Domain.Entities.Animais;
using ControleBovideoSquad.Domain.Repositories.Animais;
using ControleBovideoSquad.Domain.Repositories.Propriedades;

namespace ControleBovideoSquad.Application.Services.Animais
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly ITipoDeEntradaRepository _tipoDeEntradaRepository;
        private readonly IEspecieRepository _especieRepository;
        private readonly IPropriedadeRepository _propriedadeRepository;
        private readonly IRebanhoRepository _rebanhoRepository;
        private readonly IAnimalMapper _animalMapper;
        private readonly IRebanhoMapper _rebanhoMapper;

        public AnimalService(IAnimalRepository animalRepository, ITipoDeEntradaRepository tipoDeEntradaRepository,
            IEspecieRepository especieRepository, IAnimalMapper animalMapper, IPropriedadeRepository propriedadeRepository,
            IRebanhoRepository rebanhoRepository, IRebanhoMapper rebanhoMapper)
        {
            this._animalRepository = animalRepository;
            this._tipoDeEntradaRepository = tipoDeEntradaRepository;
            this._especieRepository = especieRepository;
            this._animalMapper = animalMapper;
            this._propriedadeRepository = propriedadeRepository;
            this._rebanhoRepository = rebanhoRepository;
            this._rebanhoMapper = rebanhoMapper;
        }

        public AnimalDto ObterPorId(int id)
        {
            var animal = _animalRepository.ObterAnimalPorId(id);
            var animalDto = _animalMapper.MapearEntidadeParaDto(animal);
            return animalDto;
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

        public Result<Animal> SalvarAnimal(AnimalDto animalDto)
        {
            var response = ValidarAnimal(animalDto);

            if (response.Any())
                return Result<Animal>.Error(EStatusCode.NOT_FOUND, response);

            var animal = _animalMapper.MapearDtoParaEntidade(animalDto);

            var rebanhoAtual = _rebanhoRepository.ObterRebanhoPorPropriedadeEEspecie(animal.PropriedadeAnimal.InscricaoEstadual, 
                animal.EspecieAnimal.IdEspecie);

            if (rebanhoAtual == null)
                this._rebanhoRepository.Save(new Rebanho(0, animalDto.QuantidadeTotal, animalDto.QuantidadeVacinada,
                    animalDto.QuantidadeVacinada, animal.EspecieAnimal, animal.PropriedadeAnimal));
            else 
                rebanhoAtual.AdicionarNoRebanho(animal.QuantidadeTotal, animal.QuantidadeVacinada);
                this._rebanhoRepository.Save(rebanhoAtual);

            this._animalRepository.Salvar(_animalMapper.MapearDtoParaEntidade(animalDto));

            return Result<Animal>.Success(_animalMapper.MapearDtoParaEntidade(animalDto));
        }

        public string CancelarAnimal(int id)
        {
            Animal animal = _animalRepository.ObterAnimalPorId(id);

            if (animal == null)
                return "animal nao encontrado";

            animal.Cancelar();
            _animalRepository.Salvar(animal);
            return "animal cancelado";
        }

        public List<string> ValidarAnimal(AnimalDto animalDto)
        {
            List<string> errors = new List<string>();

            TipoDeEntrada tipoDeEntrada = this._tipoDeEntradaRepository.ObterTipoDeEntradaPorId(animalDto.IdTipoDeEntrada);
            Especie especie = this._especieRepository.ObterEspeciePorId(animalDto.IdEspecie);
            Propriedade propriedade = this._propriedadeRepository.ObterPorId(animalDto.IdPropriedade);

            if (tipoDeEntrada == null)
                errors.Add("Tipo de entrada nao encontrado");
            if (especie == null)
                errors.Add("Especie nao encontrada");
            if (propriedade == null)
                errors.Add("Propriedade nao encontrada");

            return errors;
        }
    }
}
