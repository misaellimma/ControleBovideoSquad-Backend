using ControleBovideoSquad.Domain.Entities.Propriedades;

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

        protected Rebanho() { }

        public Rebanho(int idRebanho, int quantidadeTotal, int quantidadeVacinadaAftosa, 
            int quantidadeVacinadaBrucelose, Especie especie, Propriedade propriedade)
        {
            IdRebanho = idRebanho;
            QuantidadeTotal = quantidadeTotal;
            QuantidadeVacinadaAftosa = quantidadeVacinadaAftosa;
            QuantidadeVacinadaBrucelose = quantidadeVacinadaBrucelose;
            Especie = especie;
            Propriedade = propriedade;
        }

        public virtual void AdicionarNoRebanho(int quantidadeTotal, int quantidadeVacinada)
        {
            this.QuantidadeTotal += quantidadeTotal;
            this.QuantidadeVacinadaAftosa += quantidadeVacinada;
            this.QuantidadeVacinadaBrucelose += quantidadeVacinada;
        }

        public virtual void DebitarNoRebanho(int quantidadeTotal, int quantidadeVacinada)
        {
            this.QuantidadeTotal -= quantidadeTotal;
            this.QuantidadeVacinadaAftosa -= quantidadeVacinada;
            this.QuantidadeVacinadaBrucelose -= quantidadeVacinada;
        }

        public virtual void DebitarBrucelose(int quantidade)
        {
            this.QuantidadeVacinadaBrucelose -= quantidade;
        }

        public virtual void DebitarAftosa(int quantidade)
        {
            this.QuantidadeVacinadaAftosa -= quantidade;
        }

        public virtual void AdicionarBrucelose(int quantidade)
        {
            this.QuantidadeVacinadaBrucelose += quantidade;
        }

        public virtual void AdicionarAftosa(int quantidade)
        {
            this.QuantidadeVacinadaAftosa += quantidade;
        }
    }
}
