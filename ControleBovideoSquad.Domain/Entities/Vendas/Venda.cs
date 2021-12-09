using ControleBovideoSquad.Domain.Entities.Animais;
using ControleBovideoSquad.Domain.Entities.Propriedades;

namespace ControleBovideoSquad.Domain.Entities.Vendas
{
    public class Venda
    {
        public virtual int IdVenda { get; protected set; }
        public virtual int Quantidade { get; protected set; }
        public virtual Propriedade PropriedadeOrigem { get; protected set; }
        public virtual Propriedade PropriedadeDestino { get; protected set; }
        public virtual Especie Especie { get; protected set; }
        public virtual FinalidadeDeVenda FinalidadeDeVenda { get; protected set; }
        public virtual DateTime DataDeVenda { get; protected set; }
        public virtual bool Ativo { get; protected set; } = true;

        protected Venda() { }

        public Venda(
            int idVenda, int quantidade, Propriedade propriedadeOrigem, Propriedade propriedadeDestino,
            Especie especie, FinalidadeDeVenda finalidadeDeVenda, DateTime dataDeVenda)
        {
            this.IdVenda = idVenda;
            this.Quantidade = quantidade;   
            this.PropriedadeOrigem = propriedadeOrigem;   
            this.PropriedadeDestino = propriedadeDestino;
            this.Especie = especie;
            this.DataDeVenda = dataDeVenda;
            this.FinalidadeDeVenda = finalidadeDeVenda;
        }

        public virtual void CancelarVenda()
        {
            this.Ativo = false;
        }
    }
}
