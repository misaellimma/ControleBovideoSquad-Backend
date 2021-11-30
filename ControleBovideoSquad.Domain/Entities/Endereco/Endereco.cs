using ControleBovideoSquad.Domain.Entities.Municipios;

namespace ControleBovideoSquad.Domain.Entities.Enderecos
{
    public class Endereco
    {
        public virtual int IdEndereco { get; protected set; }
        public virtual string Rua { get; protected set; }
        public virtual string Numero { get; protected set; }
        public virtual Municipio Municipio { get; protected set; }

        protected Endereco()
        {
            Rua = "";
            Numero = "";
            Municipio = new Municipio(0,"","");
        }

        public Endereco(int idEndereco, string rua, string numero, Municipio municipio)
        {
            IdEndereco = idEndereco;
            Rua = rua;
            Numero = numero;
            Municipio = municipio;
        }
    }
}
