using Microsoft.AspNetCore.Identity;

namespace TicketsOnlineBackend.Context
{
    public class UsuarioAutenticacion : IdentityUser
    {

        public string Nombre { get; set; }
    }
}
