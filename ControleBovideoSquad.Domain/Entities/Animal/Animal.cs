using ControleBovideoSquad.Domain.Entities; 

namespace  ControleBovideoSquad.Domain.Entities.Animal
{
    public class Animal
    {
        public virtual int IdAnimal { get; protected set; }
        public virtual int QuantidadeTotal { get; protected set; }
        public virtual int QuantidadeVacinada { get; protected set; }
        public virtual Especie? EspecieAnimal { get; protected set; }
        public virtual Propriedade? PropriedadeAnimal { get; protected set; }
        public virtual TipoDeEntrada? TipoDeEntradaAnimal { get; protected set; }
        public virtual DateTime DataDeEntrada { get; protected set; }
        public virtual bool Ativo { get; protected set; }

        protected Animal()
        {
        }

        public Animal(
            int idAnimal, int quantidadeTotal, int quantidadeVacinada, 
            Especie especieAnimal, Propriedade propriedadeAnimal, TipoDeEntrada tipoDeEntradaAnimal,
            DateTime dataDeEntrada, bool ativo
            )
        {
            this.IdAnimal = idAnimal;
            this.QuantidadeTotal = quantidadeTotal;
            this.QuantidadeVacinada = quantidadeVacinada;
            this.EspecieAnimal = especieAnimal;
            this.PropriedadeAnimal = propriedadeAnimal;
            this.TipoDeEntradaAnimal = tipoDeEntradaAnimal;
            this.DataDeEntrada = dataDeEntrada;
        }
    }
}