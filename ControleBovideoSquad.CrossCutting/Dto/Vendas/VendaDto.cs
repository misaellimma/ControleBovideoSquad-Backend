namespace ControleBovideoSquad.CrossCutting.Dto.Vendas
{
    public class VendaDto
    {
        public int IdVenda { get; protected set; }
        public int Quantidade { get; protected set; }
        public int IdPropriedadeOrigem { get; protected set; }
        public int IdPropriedadeDestino { get; protected set; }
        public int IdEspecie { get; protected set; }
        public int IdFinalidadeDeVenda { get; protected set; }
        public DateTime DataDeVenda { get; protected set; }
        public bool Ativo { get; protected set; } = true;

        public VendaDto(int idVenda, int quantidade, int idPropriedadeOrigem, int idPropriedadeDestino,
            int idEspecie, int idFinalidadeDeVenda, DateTime dataDeVenda)
        {
            IdVenda = idVenda;
            Quantidade = quantidade;
            IdPropriedadeOrigem = idPropriedadeOrigem;
            IdPropriedadeDestino = idPropriedadeDestino;
            IdEspecie = idEspecie;
            IdFinalidadeDeVenda = idFinalidadeDeVenda;
            DataDeVenda = dataDeVenda;
        }
    }
}