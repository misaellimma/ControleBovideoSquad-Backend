﻿using ControleBovideoSquad.Application.IMapper.Animais;
using ControleBovideoSquad.CrossCutting.Dto.AnimaisDto;
using ControleBovideoSquad.Domain.Entities;
using ControleBovideoSquad.Domain.Entities.Animais;
using ControleBovideoSquad.Domain.Repositories.Animais;
using ControleBovideoSquad.Domain.Repositories.Propriedades;

namespace ControleBovideoSquad.Application.Mapper.Animais
{
    public class RebanhoMapper : IRebanhoMapper
    {
        private readonly IEspecieRepository _especieRepository;
        private readonly IPropriedadeRepository _propriedadeRepository;

        public RebanhoMapper(IEspecieRepository especieRepository, IPropriedadeRepository propriedadeRepository)
        {
            _especieRepository = especieRepository;
            _propriedadeRepository = propriedadeRepository;
        }

        public Rebanho MapearDtoParaEntidade(RebanhoDto source)
        {
            Especie Especie = _especieRepository.ObterEspeciePorId(source.IdEspecie);
            Propriedade Propriedade = _propriedadeRepository.ObterPorId(source.IdPropriedade);
            return new Rebanho(source.IdRebanho, source.QuantidadeTotal, source.QuantidadeVacinadaAftosa, 
                source.QuantidadeVacinadaBrucelose, Especie, Propriedade);
        }

        public RebanhoDto MapearEntidadeParaDto(Rebanho source)
        {
            return new RebanhoDto(source.IdRebanho, source.QuantidadeTotal, source.QuantidadeVacinadaAftosa,
                source.QuantidadeVacinadaBrucelose, source.Especie.IdEspecie, source.Propriedade.IdPropriedade);
        }
    }
}
