using ControleBovideoSquad.Domain.Entities.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.CrossCutting.Dto.Produtor
{
    public class ProdutorDto
    {
        public virtual int IdProdutor { get; set; }
        public virtual string Nome { get; set; }
        public virtual string CPF { get; set; }
        public virtual string Rua { get; set; }
        public virtual string Numero { get; set; }
        public virtual string Municipio { get; set; }
        public virtual string IdMunicipio { get; set; }
        public virtual string Estado { get; set; }

        public ProdutorDto(int idProdutor, string nome, string cPF, string rua, string numero, string municipio, string idMunicipio, string estado)
        {
            IdProdutor = idProdutor;
            Nome = nome;
            CPF = cPF;
            Rua = rua;
            Numero = numero;
            Municipio = municipio;
            IdMunicipio = idMunicipio;
            Estado = estado;
        }
    }
}
