using ControleBovideoSquad.Domain.Entities.Animais;
using FluentNHibernate.Mapping;

namespace ControleBovideoSquad.Repository.Mappings
{
    public class TipoDeEntradaMap : ClassMap<TipoDeEntrada>
    {
        public TipoDeEntradaMap()
        {
            Id(x => x.IdTipoDeEntrada).Column("IdTipoDeEntrada")
                .CustomSqlType("int")
                .GeneratedBy.Identity();

            Map(x => x.Nome).Column("Nome")
                .CustomSqlType("varchar")
                .Length(20)
                .Not.Nullable();
        }
    }
}
