using FoodTime.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Infraestrutura.Mapping
{
    public class AvaliacaoMapping : EntityTypeConfiguration<Avaliacao>
    {
        public AvaliacaoMapping()
        {
            ToTable("Avaliacao", "schemaFoodTime");
            HasKey(x => x.Id);
            Property(x => x.Nota).IsRequired();
            Property(x => x.PrecoMedio).HasPrecision(7, 2).IsRequired();
            Property(x => x.Recomendado).IsRequired();
            Property(x => x.Comentario).HasMaxLength(500).IsRequired();
            Property(x => x.FotoAvaliacao).HasMaxLength(500).IsRequired();
            Property(x => x.DataAvaliacao).IsRequired();
            HasRequired(x => x.Usuario).WithMany().Map(x => x.MapKey("Id_Usuario"));
            HasRequired(x => x.Estabelecimento).WithMany().Map(x => x.MapKey("Id_Estabelecimento"));
        }
    }
}
