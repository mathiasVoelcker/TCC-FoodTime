using FoodTime.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace FoodTime.Infraestrutura.Mapping
{
    public class CategoriaMapping : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMapping()
        {
            ToTable("Categoria", "schemaFoodTime");
            HasKey(x => x.Id);
            Property(x => x.Descricao).HasMaxLength(50).IsRequired();
        }
    }
}
