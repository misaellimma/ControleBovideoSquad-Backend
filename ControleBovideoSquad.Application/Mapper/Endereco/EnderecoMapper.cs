using ControleBovideoSquad.Application.IMapper;
using ControleBovideoSquad.CrossCutting.Dto.EnderecoDto;
using ControleBovideoSquad.Domain.Entities.Enderecos;
using ControleBovideoSquad.Domain.Repositories.Enderecos;
using ControleBovideoSquad.Domain.Repositories.Municipios;

namespace ControleBovideoSquad.Application.Mapper.Enderecos
{
    public class EnderecoMapper : IMapper<EnderecoDto, Endereco>
    {
        private readonly IMunicipioRepository _municipioRepository;

        public EnderecoMapper(IMunicipioRepository municipioRepository)
        {
            _municipioRepository = municipioRepository;
        }

        public Endereco MapearDtoParaEntidade(EnderecoDto enderecoDto)
        {
            var Municipio = _municipioRepository.ObterPorId(enderecoDto.IdMunicipio);
            return new Endereco(enderecoDto.IdEndereco, enderecoDto.Rua,enderecoDto.Numero, Municipio);
        }

        public EnderecoDto MapearEntidadeParaDto(Endereco endereco)
        {
            throw new NotImplementedException();
        }
    }
}
