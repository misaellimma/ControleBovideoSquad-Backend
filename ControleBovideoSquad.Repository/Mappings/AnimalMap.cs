using FluentNHibernate.Mapping;
using ControleBovideoSquad.Domain.Entities.Animais;


namespace ControleBovideoSquad.Repository.Mappings
{
    public class AnimalMap : ClassMap<Animal>
    {
        public AnimalMap()
        {
            Id(x => x.IdAnimal).Column("IdAnimal")
                .CustomSqlType("int")
                .GeneratedBy.Identity();

            Map(x => x.QuantidadeTotal).Column("QuantidadeTotal")
                .CustomSqlType("int")
                .Not.Nullable();

            Map(x => x.QuantidadeVacinada).Column("QuantidadeVacinada")
                .CustomSqlType("int")
                .Not.Nullable();

            Map(x => x.DataDeEntrada).Column("DataDeEntrada")
                .CustomSqlType("datetime")
                .Not.Nullable();

            Map(x => x.Ativo).Column("Ativo")
                .CustomSqlType("bit")
                .Not.Nullable();

            References(x => x.EspecieAnimal, "IdEspecie").Not.Nullable();

            //References(x => x.PropriedadeAnimal, "IdPropriedade").Not.Nullable();

            References(x => x.TipoDeEntradaAnimal, "IdTipoDeEntrada").Not.Nullable();
        }
    }
}
