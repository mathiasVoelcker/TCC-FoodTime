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
        DbSet<Estabelecimento> Estabelecimentos { get; set; }
        DbSet<EstabelecimentoPreferencia> EstabelecimentoPreferencias { get; set; }
        DbSet<Preferencia> Preferencias { get; set; }
        DbSet<Endereco> Enderecos { get; set; }
        DbSet<Categoria> Categorias { get; set; }
        DbSet<Foto> Fotos { get; set; }
    }
}
