using ControleBovideoSquad.Domain.Entities.Vendas;
using FluentNHibernate.Mapping;

namespace ControleBovideoSquad.Repository.Mappings
{
    public class FinalidadeDeVendaMap : ClassMap<FinalidadeDeVenda>
    {
        public FinalidadeDeVendaMap()
        {
            Id(x => x.IdFinalidadeDeVenda).Column("IdFinalidadeDeVenda")
                .CustomSqlType("int")
                .GeneratedBy.Identity();

            Map(x => x.Nome).Column("Nome")
            .CustomSqlType("varchar")
            .Not.Nullable();
        }
    }
}
