namespace ControleBovideoSquad.Domain.Entities.Animais
{
    public class TipoDeEntrada
    {
        public virtual int IdTipoDeEntrada { get; protected set; }
        public virtual string Nome { get; protected set; }

        protected TipoDeEntrada()
        {
        }

        public TipoDeEntrada(int idTipoDeEntrada, string nome)
        {
            this.IdTipoDeEntrada = idTipoDeEntrada;
            this.Nome = nome;
        }
    }
}