using ControleBovideoSquad.Domain.Entities; 

namespace  ControleBovideoSquad.Domain.Entities
{
    public class Animal
    {
        public virtual int IdAnimal { get; protected set; }
        public virtual int QuantidadeTotal { get; protected set; }
        public virtual int QuantidadeVacinada { get; protected set; }
        public virtual Especie EspecieAnimal { get; protected set; }
        public virtual Propriedade PropriedadeAnimal { get; protected set; }
        public virtual TipoDeEntrada TipoDeEntradaAnimal { get; protected set; }
        public virtual DateTime DataDeEntrada { get; protected set; }
        public virtual bool Ativo { get; protected set; }
    }
}