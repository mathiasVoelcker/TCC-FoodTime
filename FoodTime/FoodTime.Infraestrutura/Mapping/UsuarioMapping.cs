using FoodTime.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Infraestrutura.Mapping
{
    public class UsuarioMapping : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMapping()
        {
            ToTable("Usuario", "schemaFoodTime");
            HasKey(x => x.Id);
            Property(x => x.Email).HasMaxLength(100).IsRequired();
            Property(x => x.Senha).HasMaxLength(150).IsRequired();
            Property(x => x.Nome).HasMaxLength(50).IsRequired();
            Property(x => x.Sobrenome).HasMaxLength(50).IsRequired();
            Property(x => x.FotoPerfil).HasMaxLength(500).IsRequired();
            Property(x => x.DataNascimento).IsRequired();
            Property(x => x.Admin).IsRequired();
        }
    }
}
