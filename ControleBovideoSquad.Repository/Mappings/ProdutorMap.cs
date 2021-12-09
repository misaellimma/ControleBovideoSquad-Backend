using ControleBovideoSquad.Domain.Entities.Produtores;
using FluentNHibernate.Mapping;

namespace ControleBovideoSquad.Repository.Mappings
{
    public class ProdutorMap : ClassMap<Produtor>
    {
        public ProdutorMap()
        {
            Schema("dbo");
            Table("Produtor");

            Id(e => e.IdProdutor).Column("IdProdutor")
                .CustomSqlType("int")
                .GeneratedBy.Identity();

            Map(e => e.Nome).Column("Nome")
                .CustomSqlType("varchar")
                .Length(50)
                .Not.Nullable();

            Map(e => e.CPF).Column("CPF")
                .CustomSqlType("varchar")
                .Length(11)
                .Not.Nullable();

            References(x => x.Endereco, "IdEndereco").Cascade.All().Not.Nullable();

        }
    }
}
