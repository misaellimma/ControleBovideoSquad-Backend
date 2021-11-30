using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Domain.Entities.Animais
{
    public class Rebanho
    {
        public virtual int IdRebanho { get; set; }
        public virtual int QuantidadeTotal { get; set; }
        public virtual int QuantidadeVacinadaAftosa { get; set; }
        public virtual int QuantidadeVacinadaBrucelose { get; set; }
        public virtual Especie Especie { get; set; }
        public virtual Propriedade Propriedade { get; set; }
    }
}
