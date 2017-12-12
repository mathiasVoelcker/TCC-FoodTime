using FoodTime.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Infraestrutura.Mapping
{
    public class GrupoUsuarioMapping : EntityTypeConfiguration<GrupoUsuario>
    {
        public GrupoUsuarioMapping()
        {
            ToTable("Grupo_Usuario", "schemaFoodTime");
            HasKey(x => x.Id);
            HasRequired(x => x.Grupo).WithMany().Map(x => x.MapKey("Id_Grupo"));
            HasRequired(x => x.Usuario).WithMany().Map(x => x.MapKey("Id_Usuario"));
            Property(x => x.Aprovado).IsRequired();
        }
    }
}
