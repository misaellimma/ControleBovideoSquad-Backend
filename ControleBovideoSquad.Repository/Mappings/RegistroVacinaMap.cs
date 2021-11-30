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
            Id(x => x.IdRegistroVacina).Column("IdRegistroAnimal")
                .CustomSqlType("int")
                .GeneratedBy.Identity();
        }
    }
}
