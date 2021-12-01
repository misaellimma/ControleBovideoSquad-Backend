using ControleBovideoSquad.Domain.Entities.Animal;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Repository.Mappings
{
    public class RegistroVacinaMap : ClassMap<RegistroVacina>
    {
        public RegistroVacinaMap()
        {
            Table("RegistroVacinacao");

            Id(x => x.IdRegistroVacina).Column("IdRegistroVacinacao")
                .CustomSqlType("int")
                .GeneratedBy.Identity();

            Map(x => x.DataDaVacina).Column("DataDaVacina")
                .CustomSqlType("date")
                .Not.Nullable();

            Map(x => x.DataDeCadastro).Column("DataDeCadastro")
                .CustomSqlType("datetime")
                .Not.Nullable();

            Map(x => x.Quantidade).Column("Quantidade")
                .CustomSqlType("int")
                .Not.Nullable();

            Map(x => x.Ativo).Column("Ativo")
                .CustomSqlType("bit")
                .Not.Nullable();

            References(x => x.Vacina, "IdVacina").Not.Nullable();           

            References(x => x.Rebanho, "IdRebanho").Not.Nullable();

        }
    }
}
