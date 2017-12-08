using FoodTime.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace FoodTime.Infraestrutura.Mapping
{
    class PreferenciaMapping : EntityTypeConfiguration<Preferencia>
    {
        public PreferenciaMapping()
        {
            ToTable("Preferencia", "schemaFoodTime");
            HasKey(x => x.Id);
            Property(x => x.Descricao).HasMaxLength(50).IsRequired();
            Property(x => x.Aprovado).IsRequired();
        }
    }
}
