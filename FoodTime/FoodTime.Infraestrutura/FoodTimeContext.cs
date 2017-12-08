using FoodTime.Dominio.Entidades;
using FoodTime.Infraestrutura.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Infraestrutura
{
    public class FoodTimeContext : DbContext, IFoodTimeContext
    {
        public FoodTimeContext() : this("name=CrescerFoodTime") { }

        public FoodTimeContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Estabelecimento> Estabelecimentos { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<EstabelecimentoPreferencia> EstabelecimentoPreferencias { get; set; }
        public DbSet<Preferencia> Preferencias { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Foto> Fotos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioMapping());
            modelBuilder.Configurations.Add(new AvaliacaoMapping());
            modelBuilder.Configurations.Add(new EstabelecimentoMapping());
            modelBuilder.Configurations.Add(new EstabelecimentoPreferenciaMapping());
            modelBuilder.Configurations.Add(new EnderecoMapping());
            modelBuilder.Configurations.Add(new PreferenciaMapping());
            modelBuilder.Configurations.Add(new CategoriaMapping());
            modelBuilder.Configurations.Add(new FotoMapping());
            base.OnModelCreating(modelBuilder);
        }

    }
}
