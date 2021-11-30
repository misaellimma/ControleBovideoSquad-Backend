using ControleBovideoSquad.Domain.Entities.Vacinas;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Repository.Mappings
{
    public class VacinaMap : ClassMap<Vacina>
    {
        public VacinaMap()
        {
            Schema("dbo");
            Table("Vacina");

            Id(e => e.IdVacina).Column("IdVacina")
                .CustomSqlType("int")
                .GeneratedBy.Identity();

            Map(e => e.Nome).Column("Nome")
                .CustomSqlType("varchar")
                .Length(50)
                .Not.Nullable();

            Map(e => e.Doenca).Column("Doenca")
                .CustomSqlType("varchar")
                .Length(50)
                .Not.Nullable();

            Map(e => e.Tipo).Column("Tipo")
                .CustomSqlType("varchar")
                .Length(10)
                .Not.Nullable();

            Map(e => e.Marca).Column("Marca")
                .CustomSqlType("varchar")
                .Length(30)
                .Not.Nullable();
        }
    }
}
