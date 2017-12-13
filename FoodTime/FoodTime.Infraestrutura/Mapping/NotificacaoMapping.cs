using FoodTime.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Infraestrutura.Mapping
{
    public class NotificacaoMapping : EntityTypeConfiguration<Notificacao>
    {
        public NotificacaoMapping()
        {
            ToTable("Notificacao", "schemaFoodTime");
            HasKey(x => x.Id);
            Property(x => x.Visibilidade).IsRequired();
            HasRequired(x => x.Usuario).WithMany().Map(x => x.MapKey("Id_Usuario"));
            HasOptional(x => x.Estabelecimento).WithMany().Map(x => x.MapKey("Id_Estabelecimento"));
            HasOptional(x => x.Grupo).WithMany().Map(x => x.MapKey("Id_Grupo"));
        }
    }
}
