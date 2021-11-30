using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.CrossCutting.Dto.AnimaisDto.cs
{
    public class RebanhoDto
    {
        public int IdRebanho { get; set; }
        public int Quantidade { get; set; }
        public string EspecieRebanho { get; set; }
        public string PropriedadeRebanho { get; set; }

        public RebanhoDto(int idRebanho, int quantidade, string especieRebanho, string propriedadeRebanho)
        {
            IdRebanho = idRebanho;
            Quantidade = quantidade;
            EspecieRebanho = especieRebanho;
            PropriedadeRebanho = propriedadeRebanho;
        }
    }
}
