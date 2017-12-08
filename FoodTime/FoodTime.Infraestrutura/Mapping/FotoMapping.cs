using FoodTime.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace FoodTime.Infraestrutura.Mapping
{
    public class FotoMapping : EntityTypeConfiguration<Foto>
    {
        public FotoMapping()
        {
            ToTable("Foto", "schemaFoodTime");
            HasKey(x => x.Id);
            Property(x => x.Path).HasMaxLength(200).IsRequired();
            HasRequired(x => x.Estabelecimento).WithMany().Map(x => x.MapKey("IdEstabelecimento"));
        }
    }
}
