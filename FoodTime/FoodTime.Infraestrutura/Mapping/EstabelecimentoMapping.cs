using FoodTime.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Infraestrutura.Mapping
{
    public class EstabelecimentoMapping : EntityTypeConfiguration<Estabelecimento>
    {
        public EstabelecimentoMapping()
        {
            ToTable("Estabelecimento", "schemaFoodTime");
            HasKey(x => x.Id);
            Property(x => x.Nome).HasMaxLength(100).IsRequired();
            Property(x => x.Telefone).HasMaxLength(12).IsRequired();
            Property(x => x.PrecoMedio).HasPrecision(7, 2).IsRequired();
            Property(x => x.HorarioAbertura).IsRequired();
            Property(x => x.HorarioFechamento).IsRequired();
            HasRequired(x => x.Endereco).WithMany().Map(x => x.MapKey("Id_Endereco"));
            HasMany(x => x.Categorias).WithMany().Map(x =>
            {
                x.ToTable("Estabelecimento_Categoria", "schemaFoodTime");
                x.MapLeftKey("Id_Estabelecimento");
                x.MapRightKey("Id_Categoria");
            });
            HasMany(x => x.Fotos).WithRequired().Map(x => x.MapKey("Id_Estabelecimzento"));
        }
    }
}
