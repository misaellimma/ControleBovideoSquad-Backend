using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< HEAD
namespace ControleBovideoSquad.Domain.Entities
=======
namespace ControleBovideoSquad.Domain.Entities.Municipios
>>>>>>> 1360958a3d0367f7201922f17911d6248775f151
{
    public class Municipio
    {
        public virtual int IdMunicipio { get; protected set; }
        public virtual string? Nome { get; protected set; }
        public virtual string? Estado { get; protected set; }

        protected Municipio()
        {
        }

        public Municipio(int idMunicipio, string nome, string estado)
        {
            IdMunicipio = idMunicipio;
            Nome = nome;
            Estado = estado;
        }

        public Municipio(int idMunicipio)
        {
            IdMunicipio = idMunicipio;
        }
    }

}
