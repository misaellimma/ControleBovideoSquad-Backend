using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.CrossCutting.Dto.AnimaisDto.cs
{
    public class AnimalDto
    {
        public int IdAnimal { get; set; }
        public int Quantidade { get; set; }
        public string EspecieAnimal { get; set; }
        public string PropriedadeAnimal {  get; set; }

        public AnimalDto(int idAnimal, int quantidade, string especieAnimal, string propriedadeAnimal)
        {
            IdAnimal = idAnimal;
            Quantidade = quantidade;
            EspecieAnimal = especieAnimal;
            PropriedadeAnimal = propriedadeAnimal;
        }
    }
}
