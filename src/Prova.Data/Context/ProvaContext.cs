using Microsoft.EntityFrameworkCore;
using Prova.Bussiness.Models;

namespace Prova.Data.Context
{
    public class ProvaContext : DbContext
    {
        public ProvaContext(DbContextOptions options) : base(options) { }

        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProvaContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}