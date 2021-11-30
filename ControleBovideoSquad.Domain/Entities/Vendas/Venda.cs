namespace ControleBovideoSquad.Domain.Entities.Vendas
{
    public class Venda
    {
        public virtual int IdVenda { get; protected set; }
        public virtual int Quantidade { get; protected set; }
        public virtual Propriedade PropriedadeOrigem { get; protected set; }
        public virtual Propriedade PropriedadeDestino { get; protected set; }
        public virtual int IdRebanho { get; protected set; }
        public virtual FinalidadeDeVenda FinalidadeDeVenda { get; protected set; }
        public virtual DateTime DataDeVenda { get; protected set; }
        public virtual bool Ativo { get; protected set; }

        protected Venda() { }

        public Venda(
            int idVenda, int quantidade, Propriedade propriedadeOrigem, Propriedade propriedadeDestino,
            int idRebanho, FinalidadeDeVenda finalidadeDeVenda, DateTime dataDeVenda, bool ativo)
        {
            this.IdVenda = idVenda;
            this.Quantidade = quantidade;   
            this.PropriedadeOrigem = propriedadeOrigem;   
            this.PropriedadeDestino = propriedadeDestino;
            this.Ativo = ativo;
            this.IdRebanho = idRebanho;
            this.DataDeVenda = dataDeVenda;
            this.FinalidadeDeVenda = finalidadeDeVenda;
        }
    }
}
