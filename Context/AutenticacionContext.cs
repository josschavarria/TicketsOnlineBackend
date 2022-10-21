using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TicketsOnlineBackend.Context
{
    public class AutenticacionContext : IdentityDbContext
    {

        public AutenticacionContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<UsuarioAutenticacion> User { get; set; }
    }
}
