using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Domain.Entities.Vendas
{
    public class FinalidadeDeVenda
    {
        public virtual int IdFinalidadeDeVenda { get; protected set; }
        public virtual string Nome { get; protected set; }

        protected FinalidadeDeVenda()
        {
            IdFinalidadeDeVenda = 0;
            Nome = "";
        }
        public FinalidadeDeVenda(int idFinalidadeDeVenda, string nome)
        {
            IdFinalidadeDeVenda = idFinalidadeDeVenda;
            Nome = nome;
        }
    }
}
