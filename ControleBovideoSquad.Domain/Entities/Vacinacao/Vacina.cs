using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Domain.Entities.Vacinacao
{
    public class Vacina
    {
        public virtual int IdVacina { get; protected set; }
        public virtual string Nome{ get; protected set; }
        public virtual string Doenca { get; protected set; }
        public virtual string Tipo { get; protected set; }
        public virtual string Marca { get; protected set; }

        protected Vacina()
        {
        }

        public Vacina(int idVacina, string nome, string doenca, string tipo, string marca)
        {
            IdVacina = idVacina;
            Nome = nome;
            Doenca = doenca;
            Tipo = tipo;
            Marca = marca;
        }
    }
}
