namespace ControleBovideoSquad.Domain.Entities.Animais
{
    public class Especie
    {

        public virtual int IdEspecie { get; protected set; }
        public virtual string Nome { get; protected set; }

        protected Especie()
        {

        }

        public Especie(int idEspecie, string nome)
        {
            IdEspecie = idEspecie;
            Nome = nome;
        }
    }
}