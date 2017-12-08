using FoodTime.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Infraestrutura
{
    public interface IFoodTimeContext
    {
        int SaveChanges();

        DbSet<Usuario> Usuarios { get; set; }
        DbSet<Avaliacao> Avaliacoes { get; set; }

    }
}
