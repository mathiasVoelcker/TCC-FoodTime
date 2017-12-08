using FoodTime.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Infraestrutura.Mapping
{
    public class FotoMapping : EntityTypeConfiguration<Foto>
    {
        public FotoMapping()
        {
            ToTable("Foto", "schemaFoodTime");
            HasKey(x => x.Id);
            Property(x => x.Path).HasMaxLength(500).IsRequired();
        }
    }
}
