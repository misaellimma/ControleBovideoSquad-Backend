using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.CrossCutting.Dto.Propriedade
{
    public class PropriedadeDto
    {
        public virtual int IdPropriedade { get; protected set; }
        public virtual string InscricaoEstadual { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual int IdProdutor { get; protected set; }
        public virtual string NomeProdutor { get; protected set; }
        public virtual int idEndereco { get; protected set; }
        public virtual string Rua { get; protected set; }
        public virtual string Numero { get; protected set; }
        public virtual int IdMunicipio { get; protected set; }
        public virtual string Municipio { get; protected set; }
        public virtual string Estado { get; protected set; }
    }
}
