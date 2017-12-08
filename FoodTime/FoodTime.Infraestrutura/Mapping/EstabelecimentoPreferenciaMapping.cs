using FoodTime.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Infraestrutura.Mapping
{
    public class EstabelecimentoPreferenciaMapping : EntityTypeConfiguration<EstabelecimentoPreferencia>
    {
        public EstabelecimentoPreferenciaMapping()
        {
            ToTable("Estabelecimento_Preferencia", "schemaFoodTime");
            HasKey(x => x.Id);
            HasRequired(x => x.Estabelecimento).WithMany().Map(x => x.MapKey("Id_Estabelecimento"));
            HasRequired(x => x.Preferencia).WithMany().Map(x => x.MapKey("Id_Preferencia"));
            Property(x => x.Aprovado).IsRequired();
        }
    }
}
