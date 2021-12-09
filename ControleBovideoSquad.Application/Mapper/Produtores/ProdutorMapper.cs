using ControleBovideoSquad.Application.IMapper.Produtores;
using ControleBovideoSquad.CrossCutting.Dto.Produtores;
using ControleBovideoSquad.Domain.Entities.Enderecos;
using ControleBovideoSquad.Domain.Entities.Produtores;

namespace ControleBovideoSquad.Application.Mapper.Produtores
{
    public class ProdutorMapper : IProdutorMapper
    {
        public ProdutorMapper()
        {
        }

        public Produtor MapearDtoParaEntidade(ProdutorDto produtorDto)
        {
            Municipio municipio = new Municipio
                (
                    produtorDto.IdMunicipio,
                    produtorDto.Municipio,
                    produtorDto.Estado
                );

            Endereco endereco = new Endereco
                (
                    0,
                    produtorDto.Rua,
                    produtorDto.Numero,
                    municipio
                );

            return new Produtor
                (
                    produtorDto.IdProdutor,
                    produtorDto.Nome,
                    produtorDto.CPF,
                    endereco
                );
        }

        public List<ProdutorDto> MapearEntidadeParaDto(List<Produtor> produtores)
        {
            var produtoresDto = new List<ProdutorDto>();
            if (produtores.Any())
                foreach(Produtor produtor in produtores)
                {
                    var produtorDto = new ProdutorDto
                        (
                            produtor.IdProdutor,
                            produtor.Nome,
                            produtor.CPF,
                            produtor.Endereco.IdEndereco,
                            produtor.Endereco.Rua,
                            produtor.Endereco.Numero,
                            produtor.Endereco.Municipio.Nome,
                            produtor.Endereco.Municipio.IdMunicipio,
                            produtor.Endereco.Municipio.Estado
                        );
                    produtoresDto.Add(produtorDto);
                }
            return produtoresDto;
        }

        public ProdutorDto MapearEntidadeParaDto(Produtor produtor)
        {
            return new ProdutorDto
                (
                    produtor.IdProdutor,
                    produtor.Nome,
                    produtor.CPF,
                    produtor.Endereco.IdEndereco,
                    produtor.Endereco.Rua,
                    produtor.Endereco.Numero,
                    produtor.Endereco.Municipio.Nome,
                    produtor.Endereco.Municipio.IdMunicipio,
                    produtor.Endereco.Municipio.Estado
                );
        }
    }
}
