using ControleBovideoSquad.Domain.Entities.Enderecos;
using FluentNHibernate.Mapping;

namespace ControleBovideoSquad.Repository.Mappings
{
    public class EnderecoMap : ClassMap<Endereco>
    {
        public EnderecoMap()
        {
            Table("Endereco");

            Id(x => x.IdEndereco).Column("IdEndereco")
                .CustomSqlType("int")
                .GeneratedBy.Identity();

            Map(x => x.Rua).Column("Rua")
                .CustomSqlType("varchar")
                .Length(50)
                .Not.Nullable();

            Map(x => x.Numero)
                .Column("Numero")
                .CustomSqlType("varchar")
                .Length(11)
                .Not.Nullable();

            References(x => x.Municipio, "IdMunicipio").Not.Nullable();
        }
    }
}
