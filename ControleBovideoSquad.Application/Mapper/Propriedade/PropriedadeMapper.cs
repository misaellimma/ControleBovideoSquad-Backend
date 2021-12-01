using ControleBovideoSquad.Application.IMapper;
using ControleBovideoSquad.CrossCutting.Dto.Propriedade;
using ControleBovideoSquad.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.Mapper.Propriedades
{
    internal class PropriedadeMapper : IMapper<PropriedadeDto, Propriedade>
    {
        public Propriedade MapearDtoParaEntidade(PropriedadeDto source)
        {
            throw new NotImplementedException();
        }

        public PropriedadeDto MapearEntidadeParaDto(Propriedade source)
        {
            throw new NotImplementedException();
        }
    }
}
