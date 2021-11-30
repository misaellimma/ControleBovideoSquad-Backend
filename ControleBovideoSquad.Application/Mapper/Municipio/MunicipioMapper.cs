//using AutoMapper;
using ControleBovideoSquad.Application.IMapper;
using ControleBovideoSquad.CrossCutting.Dto.Municipio;
<<<<<<< HEAD
using ControleBovideoSquad.Domain.Entities;
=======
using ControleBovideoSquad.Domain.Entities.Municipios;
>>>>>>> 1360958a3d0367f7201922f17911d6248775f151
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.Mapper
{
    public class MunicipioMapper :IMapper<MunicipioDto, Municipio>
    {
        public Municipio MapearDtoParaEntidade(MunicipioDto municipioDto)
        {
            return new Municipio(
                municipioDto.IdMunicipio,
                municipioDto.Nome,
                municipioDto.UF);
        }

        public MunicipioDto MapearEntidadeParaDto(Municipio municipio)
        {
            return new MunicipioDto
            {
                IdMunicipio = municipio.IdMunicipio,
                Nome = municipio.Nome,
                UF = municipio.Nome
            };
        }

        public List<MunicipioDto> MapearEntidadeParaDto(List<Municipio> municipio)
        {
            var municipios = municipio.Select(MapearEntidadeParaDto).ToList();
            return municipios;
        }

    }
}
