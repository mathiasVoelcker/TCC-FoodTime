using FoodTime.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Infraestrutura.Mapping
{
    public class GrupoMapping : EntityTypeConfiguration<Grupo>
    {
        public GrupoMapping()
        {
            ToTable("Grupo", "schemaFoodTime");
            HasKey(x => x.Id);
            Property(x => x.Nome).HasMaxLength(50).IsRequired();
            Property(x => x.Foto).HasMaxLength(500).IsRequired();
        }
    }
}
