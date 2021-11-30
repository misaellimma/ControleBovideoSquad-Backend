using ControleBovideoSquad.CrossCutting.Dto.Produtor;
using ControleBovideoSquad.Domain.Entities.Produtores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.IMapper.Produtores
{
    public interface IProdutorMapper : IMapper<ProdutorDto, Produtor>
    {
        List<ProdutorDto> MapearEntidadeParaDto(List<Produtor> produtores);
    }
}
