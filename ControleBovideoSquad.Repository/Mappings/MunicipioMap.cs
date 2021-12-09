using ControleBovideoSquad.Domain.Entities.Enderecos;
using FluentNHibernate.Mapping;

namespace ControleBovideoSquad.Repository.Mappings
{
    internal class MunicipioMap : ClassMap<Municipio>
    {
        public MunicipioMap()
        {
            Schema("dbo");
            Table("Municipio");

            Id(e => e.IdMunicipio).Column("IdMunicipio")
                .CustomSqlType("int")
                .GeneratedBy.Identity();

            Map(e => e.Nome).Column("Nome")
                .CustomSqlType("varchar")
                .Length(50)
                .Not.Nullable();

            Map(e => e.Estado).Column("Estado")
                .CustomSqlType("varchar")
                .Length(2)
                .Not.Nullable();
        }
    }
}
