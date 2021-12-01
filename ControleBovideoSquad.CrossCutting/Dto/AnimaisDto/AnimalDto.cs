using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.CrossCutting.Dto.AnimaisDto
{
    public class AnimalDto
    {
        public int IdAnimal { get; set; }
        public int QuantidadeTotal { get; set; }
        public int QuantidadeVacinada { get; set; }
        public int IdEspecie { get; set; }
        public int IdPropriedade { get; set; }
        public int IdTipoDeEntrada { get; set; }
        public DateTime DataDeEntrada { get; set; }
        public bool Ativo { get; set; }

        public AnimalDto(int idAnimal, int quantidadeTotal, int quantidadeVacinada, int idEspecie, 
            int idPropriedade, int idTipoDeEntrada, DateTime dataDeEntrada, bool ativo)
        {
            IdAnimal = idAnimal;
            QuantidadeTotal = quantidadeTotal;
            QuantidadeVacinada = quantidadeVacinada;
            IdEspecie = idEspecie;
            IdPropriedade = idPropriedade;
            IdTipoDeEntrada = idTipoDeEntrada;
            DataDeEntrada = dataDeEntrada;
            Ativo = ativo;
        }
    }
}
