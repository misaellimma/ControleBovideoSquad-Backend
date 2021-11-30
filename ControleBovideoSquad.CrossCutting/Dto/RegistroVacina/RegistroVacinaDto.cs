using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.CrossCutting.Dto.RegistroVacina
{
    public class RegistroVacinaDto
    {
        public int IdRegistroVacina { get; set; }
        public int Quantidade { get; set; }
        public int IdVacina { get; set; }
        public int IdRebanho { get; set; }
        public DateTime DataDaVacina { get; set; }

        public RegistroVacinaDto(int idRegistroVacina, int quantidade, int idVacina, int idRebanho, DateTime dataDaVacina)
        {
            IdRegistroVacina = idRegistroVacina;
            Quantidade = quantidade;
            IdVacina = idVacina;
            IdRebanho = idRebanho;
            DataDaVacina = dataDaVacina;
        }   
    }
}
