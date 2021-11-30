using ControleBovideoSquad.Application.IMapper.Produtores;
using ControleBovideoSquad.CrossCutting.Dto.Produtor;
using ControleBovideoSquad.Domain.Entities.Produtores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.Mapper.Produtores
{
    public class ProdutorMapper : IProdutorMapper
    {
        public Produtor MapearDtoParaEntidade(ProdutorDto source)
        {
            throw new NotImplementedException();
        }

        public List<ProdutorDto> MapearEntidadeParaDto(List<Produtor> produtores)
        {
            var produtoresDto = new List<ProdutorDto>();
            if (produtores.Any())
                foreach(Produtor produtor in produtores)
                {
                    var produtorDto = new ProdutorDto(produtor.IdProdutor,
                                                      produtor.Nome,
                                                      produtor.CPF,
                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      ""
                                                      );
                    produtoresDto.Add(produtorDto);
                }
            return produtoresDto;
        }

        public ProdutorDto MapearEntidadeParaDto(Produtor source)
        {
            throw new NotImplementedException();
        }
    }
}
