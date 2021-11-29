using ControleBovideoSquad.Domain.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Repository.Mappings
{
    public class EspecieMap : ClassMap<Especie>
    {
        public EspecieMap()
        {
            Table("Especie");


            Id(x => x.IdEspecie).Column("IdEspecie")
                .CustomSqlType("int")
                .GeneratedBy.Identity();

            Map(x => x.Nome).Column("Nome")
               .CustomSqlType("varchar")
               .Length(30)
               .Not.Nullable();
        }
    }
}
