using ControleBovideoSquad.Domain.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Repository.Mappings
{
    internal class PropriedadeMap : ClassMap<Propriedade>
    {
        public PropriedadeMap()
        {
            Schema("dbo");
            Table("Propriedade");

            Id(e => e.IdPropriedade).Column("IdPropriedade")
                .CustomSqlType("int")
                .GeneratedBy.Identity();

            Map(e => e.InscricaoEstadual).Column("InscricaoEstadual")
                .CustomSqlType("varchar")
                .Length(10)
                .Not.Nullable();

            Map(e => e.Nome).Column("Nome")
                .CustomSqlType("varchar")
                .Length(50)
                .Not.Nullable();

            References(x => x.Endereco, "IdEndereco").Not.Nullable().Cascade.SaveUpdate();

            References(x => x.Produtor, "IdProdutor").Not.Nullable();
        }
    }
}
