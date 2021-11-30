using ControleBovideoSquad.Domain.Entities.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Domain.Entities.Produtores
{
    public class Produtor
    {
        public virtual int IdProdutor { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual string CPF { get; protected set; }
        public virtual Endereco Endereco { get; protected set; }

        protected Produtor()
        {
        }

        public Produtor(int idProdutor, string nome, string cpf, Endereco endereco)
        {
            IdProdutor = idProdutor;
            Nome = nome;
            CPF = cpf;
            this.Endereco = endereco;
        }
    }
}
