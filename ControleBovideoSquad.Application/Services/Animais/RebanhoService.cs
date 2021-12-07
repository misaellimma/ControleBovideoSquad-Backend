﻿using ControleBovideoSquad.Application.IMapper.Animais;
using ControleBovideoSquad.Application.IServices.Animais;
using ControleBovideoSquad.Application.Mapper.Animais;
using ControleBovideoSquad.CrossCutting;
using ControleBovideoSquad.CrossCutting.Dto.AnimaisDto;
using ControleBovideoSquad.CrossCutting.Util;
using ControleBovideoSquad.Domain.Entities;
using ControleBovideoSquad.Domain.Entities.Animais;
using ControleBovideoSquad.Domain.Repositories.Animais;
using ControleBovideoSquad.Domain.Repositories.Propriedades;

namespace ControleBovideoSquad.Application.Services.Animais
{
    public class RebanhoService : IRebanhoService
    {
        private readonly IRebanhoRepository _rebanhoRepository;
        private readonly IPropriedadeRepository _propriedadeRepository;
        private readonly IEspecieRepository _especieRepository;
        private readonly IRebanhoMapper _rebanhoMapper;

        public RebanhoService(IRebanhoRepository rebanhoRepository, IRebanhoMapper rebanhoMapper, 
            IPropriedadeRepository propriedadeRepository,
            IEspecieRepository especieRepository)
        {
            _rebanhoRepository = rebanhoRepository; 
            _rebanhoMapper = rebanhoMapper;
            _propriedadeRepository = propriedadeRepository;
            _especieRepository = especieRepository;
        }

        public Rebanho ObterRebanhoPorId(int id)
        {
            return _rebanhoRepository.ObterRebanhosPorId(id);
        }

        public List<RebanhoDto> ObterRebanhos()
        {
            return _rebanhoMapper.MaperListaEntidadeParaDto(_rebanhoRepository.ObterRebanhos());
        }

        public List<RebanhoDto> ObterRebanhosPorProdutor(string cpf)
        {
            cpf = Formatar.FormatarString(cpf);
            return _rebanhoMapper.MaperListaEntidadeParaDto(_rebanhoRepository.ObterRebanhosPorProdutor(cpf));
        }

        public List<RebanhoDto> ObterRebanhosPorPropriedade(string inscricaoEstadual)
        {
            return _rebanhoMapper.MaperListaEntidadeParaDto(_rebanhoRepository.ObterRebanhosPorPropriedade(inscricaoEstadual));
        }

        public Rebanho ObterRebanhoPorPropriedadeEEspecie(string inscricaoEstadual, int idEspecie)
        {
            return _rebanhoRepository.ObterRebanhoPorPropriedadeEEspecie(inscricaoEstadual, idEspecie);
        }

        public Result<Rebanho> SalvarRebanho(RebanhoDto rebanhoDto)
        {
            var response =  ValidarRebanho(rebanhoDto);

            if (response.Any())
                return Result<Rebanho>.Error(EStatusCode.BAD_REQUEST,response);

            Rebanho rebanho = this._rebanhoMapper.MapearDtoParaEntidade(rebanhoDto);
            this._rebanhoRepository.Save(rebanho);

            return Result<Rebanho>.Success(rebanho);
        }

        public List<string> ValidarRebanho(RebanhoDto rebanhoDto)
        {
            List<string> errors = new List<string>();

            Especie especie = this._especieRepository.ObterEspeciePorId(rebanhoDto.IdEspecie);
            Propriedade propriedade = this._propriedadeRepository.ObterPorId(rebanhoDto.IdPropriedade);

            if (especie == null)
                errors.Add("Especie nao encontrada");
            if (propriedade == null)
                errors.Add("Propriedade nao encontrada");

            return errors;
        }
    }
}
