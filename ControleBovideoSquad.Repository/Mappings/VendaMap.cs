using FluentNHibernate.Mapping;
using ControleBovideoSquad.Domain.Entities.Vendas;

namespace ControleBovideoSquad.Repository.Mappings
{
    public class VendaMap : ClassMap<Venda>
    {
        public VendaMap()
        {
            Id(x => x.IdVenda).Column("IdVenda")
                .CustomSqlType("int")
                .GeneratedBy.Identity();

            Map(x => x.Quantidade).Column("Quantidade")
                .CustomSqlType("int")
                .Not.Nullable();

            Map(x => x.DataDeVenda).Column("DataDeVenda")
                .CustomSqlType("datetime")
                .Not.Nullable();

            Map(x => x.Ativo).Column("Ativo")
                .CustomSqlType("bit")
                .Not.Nullable();

            References(x => x.PropriedadeOrigem, "IdOrigem").Not.Nullable();
            References(x => x.PropriedadeDestino, "IdDestino").Not.Nullable();
            References(x => x.FinalidadeDeVenda, "IdFinalidadeDeVenda").Not.Nullable();
            References(x => x.Especie, "IdEspecie").Not.Nullable();
        }
    }
}
