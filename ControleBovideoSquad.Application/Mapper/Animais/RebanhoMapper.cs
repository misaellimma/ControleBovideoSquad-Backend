using ControleBovideoSquad.Application.IMapper;
using ControleBovideoSquad.CrossCutting.Dto.AnimaisDto.cs;
using ControleBovideoSquad.Domain.Entities.Animais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.Mapper.Animais
{
    public class RebanhoMapper : IMapper<RebanhoDto, Rebanho>
    {
        public Rebanho MapearDtoParaEntidade(RebanhoDto source)
        {
            throw new NotImplementedException();
        }

        public RebanhoDto MapearEntidadeParaDto(Rebanho source)
        {
            return new RebanhoDto(source.IdRebanho, source.QuantidadeTotal, source.Especie.Nome, "propriedade");
        }
    }
}
