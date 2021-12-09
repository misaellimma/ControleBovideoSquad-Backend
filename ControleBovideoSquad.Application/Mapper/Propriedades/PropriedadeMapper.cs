using ControleBovideoSquad.Application.IMapper.Propriedades;
using ControleBovideoSquad.CrossCutting.Dto.Propriedades;
using ControleBovideoSquad.Domain.Entities.Propriedades;
using ControleBovideoSquad.Domain.Entities.Enderecos;
using ControleBovideoSquad.Domain.Entities.Produtores;
using ControleBovideoSquad.Domain.Repositories.Produtores;

namespace ControleBovideoSquad.Application.Mapper.Propriedades
{
    public class PropriedadeMapper : IPropriedadeMapper
    {
        private readonly IProdutorRepository produtorRepository;

        public PropriedadeMapper(IProdutorRepository produtorRepository)
        {
            this.produtorRepository = produtorRepository;
        }

        public Propriedade MapearDtoParaEntidade(PropriedadeDto source)
        {
            Endereco endereco = new Endereco
                (
                    0,
                    source.Rua,
                    source.Numero,
                    new Municipio(source.IdMunicipio)
                );            

            return new Propriedade
                (
                    source.IdPropriedade,
                    source.InscricaoEstadual,
                    source.Nome,
                    endereco,
                    new Produtor(source.IdProdutor)
                );
        }

        public PropriedadeDto MapearEntidadeParaDto(Propriedade source)
        {
            return new PropriedadeDto
                (
                source.IdPropriedade,
                source.InscricaoEstadual,
                source.Nome,
                source.Produtor.IdProdutor,
                source.Produtor.Nome,
                source.Endereco.IdEndereco,
                source.Endereco.Rua,
                source.Endereco.Numero,
                source.Endereco.Municipio.IdMunicipio,
                source.Endereco.Municipio.Nome,
                source.Endereco.Municipio.Estado
                );
        }

        public List<PropriedadeDto> MapearEntidadeParaDto(List<Propriedade> propriedades)
        {
            var propriedadesDto = new List<PropriedadeDto>();
            if (propriedades.Any())
                foreach (Propriedade propriedade in propriedades)
                {
                    var propriedadeDto = new PropriedadeDto
                        (
                            propriedade.IdPropriedade,
                            propriedade.InscricaoEstadual,
                            propriedade.Nome,
                            propriedade.Produtor.IdProdutor,
                            propriedade.Produtor.Nome,
                            propriedade.Endereco.IdEndereco,
                            propriedade.Endereco.Rua,
                            propriedade.Endereco.Numero,
                            propriedade.Endereco.Municipio.IdMunicipio,
                            propriedade.Endereco.Municipio.Nome,
                            propriedade.Endereco.Municipio.Estado
                        );
                    propriedadesDto.Add(propriedadeDto);
                }
            return propriedadesDto;
        }
    }
}
