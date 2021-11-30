namespace ControleBovideoSquad.Domain.Entities.Animal
{
    public class RegistroVacina
    {
        public virtual int IdRegistroVacina { get; protected set; }
        public virtual int Quantidade { get; protected set; }
        public virtual DateTime DataDaVacina { get;protected set; }
        public virtual DateTime DataDeCadastro { get;protected set; } = DateTime.Now;
        public virtual bool Ativo { get; protected set; } = true;
        //public Vacina Vacina { get; protected set; }
        //public Rebanho Rebanho { get; protected set; }

    }
}
