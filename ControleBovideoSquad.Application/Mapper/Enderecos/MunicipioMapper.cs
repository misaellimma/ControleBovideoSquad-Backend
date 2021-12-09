using ControleBovideoSquad.Application.IMapper;
using ControleBovideoSquad.CrossCutting.Dto.Enderecos;
using ControleBovideoSquad.Domain.Entities.Enderecos;

namespace ControleBovideoSquad.Application.Mapper.Enderecos
{
    public class MunicipioMapper : IMapper<MunicipioDto, Municipio>
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
