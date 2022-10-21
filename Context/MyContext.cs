using Microsoft.EntityFrameworkCore;
using TicketsOnlineBackend.Context.Mapping;
using TicketsOnlineBackend.Models;

namespace TicketsOnlineBackend.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        public DbSet<Capacidad>? Capacidad { get; set; }

        public DbSet<Categoria>? Categoria { get; set; }

        public DbSet<Evento>? Evento { get; set; }

        public DbSet<Tarjeta>? Tarjeta { get; set; }

        public DbSet<Ticket>? Ticket { get; set; }

        public DbSet<Models.Usuario>? Usuario { get; set; }

        public DbSet<Vendor>? Vendor { get; set; }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaMaps());
            base.OnModelCreating(modelBuilder);
        }

    }
}
