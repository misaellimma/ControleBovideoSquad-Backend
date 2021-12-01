using ControleBovideoSquad.CrossCutting.Dto.Propriedade;
using ControleBovideoSquad.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.IMapper.Propriedades
{
    public interface IPropriedadeMapper: IMapper<PropriedadeDto, Propriedade>
    {
       List<PropriedadeDto> MapearEntidadeParaDto(List<Propriedade> produtores);

    }
}
