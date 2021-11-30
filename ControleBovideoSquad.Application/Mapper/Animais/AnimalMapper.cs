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
    public class AnimalMapper : IMapper<AnimalDto, Animal>
    {
        public Animal MapearDtoParaEntidade(AnimalDto source)
        {
            throw new NotImplementedException();
        }

        public AnimalDto MapearEntidadeParaDto(Animal source)
        {
            return new AnimalDto(source.IdAnimal, source.QuantidadeTotal, source.EspecieAnimal.Nome, "propriedade");
        }
    }
}
