using ControleBovideoSquad.Domain.Entities.Animais;
using FluentNHibernate.Mapping;

namespace ControleBovideoSquad.Repository.Mappings
{
    public class RebanhoMap : ClassMap<Rebanho>
    {
        public RebanhoMap()
        {
            Id(x => x.IdRebanho).Column("idRebanho")
                .CustomSqlType("int")
                .GeneratedBy.Identity();

            Map(x => x.QuantidadeTotal).Column("QuantidadeTotal")
                .CustomSqlType("int")
                .Not.Nullable();

            Map(x => x.QuantidadeVacinadaBrucelose).Column("QuantidadeVacinadaBrucelose")
                .CustomSqlType("int")
                .Not.Nullable();

            Map(x => x.QuantidadeVacinadaAftosa).Column("QuantidadeVacinadaAftosa")
                .CustomSqlType("int")
                .Not.Nullable();

            References(x => x.Especie, "idEspecie").Not.Nullable();
            References(x => x.Propriedade, "idPropriedade").Not.Nullable();
        }
    }
}
