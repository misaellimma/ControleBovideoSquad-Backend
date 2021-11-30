using ControleBovideoSquad.Domain.Entities.Animais;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
