using ControleBovideoSquad.Domain.Entities.Animais;
using ControleBovideoSquad.Domain.Entities.Vacinas;

namespace ControleBovideoSquad.Domain.Entities.Animal
{
    public class RegistroVacina
    {   

        public virtual int IdRegistroVacina { get; protected set; }
        public virtual int Quantidade { get; protected set; }
        public virtual DateTime DataDaVacina { get;protected set; }
        public virtual DateTime DataDeCadastro { get;protected set; } = DateTime.Now;
        public virtual bool Ativo { get; protected set; } = true;
        public virtual Vacina Vacina { get; protected set; }
        public virtual Rebanho Rebanho { get; protected set; }

        protected RegistroVacina()
        {
        }

        public RegistroVacina(int idRegistroVacina, int quantidade, DateTime dataDaVacina, Vacina vacina ,Rebanho rebanho)
        {
            IdRegistroVacina = idRegistroVacina;
            Quantidade = quantidade;
            DataDaVacina = dataDaVacina;
            Vacina = vacina;
            Rebanho = rebanho;
        }

        public virtual void Cancelar()
        {
            Ativo = false;
        }

    }
}
