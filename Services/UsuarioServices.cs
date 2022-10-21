using Microsoft.EntityFrameworkCore;
using TicketsOnlineBackend.Context;
using TicketsOnlineBackend.Helppers;
using TicketsOnlineBackend.Models;

namespace TicketsOnlineBackend.Services
{
    public class UsuarioServices
    {

            private readonly MyContext _context;

            public UsuarioServices(MyContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Usuario>> GetAll()
            {
                return await _context.Usuario.ToListAsync();
            }

            public async Task<Response> GetById(long id)
            {
                var user = await _context.Usuario.FirstOrDefaultAsync(r => r.Id == id);
                if (user == null)
                {
                    return new Response { Message = "Usuario no existe." };
                }

                return new Response { Data = user };
            }

            public async Task<Response> PostUsuario(Usuario user)
            {
                if (string.IsNullOrEmpty(user.PrimerNombre)
                    || string.IsNullOrEmpty(user.PrimerApellido) || string.IsNullOrEmpty(user.SegundoApellido)
                    || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.EmailConfirmacion)
                    || string.IsNullOrEmpty(user.Clave) || string.IsNullOrEmpty(user.ClaveConfirmacion)
                    || string.IsNullOrEmpty(user.Pais) || string.IsNullOrEmpty(user.Departamento)
                    )
                {
                    return new Response { Message = "Por favor llenar los campos vacios." };
                }


                _context.Usuario.Add(user);
                await _context.SaveChangesAsync();
                return new Response { Message = "Agregado Correctamente." };
            }

            public async Task<Response> PutUsuario(Usuario user)
            {
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return new Response { Message = "Informacion modificada existosamente" };
            }

            public async Task<Response> DeleteUsuario(int id)
            {
                var user = await _context.Usuario.FindAsync(id);
                if (user == null)
                {
                    return "No existe usuario con este numero de ID.";
                }
                _context.Usuario.Remove(user);
                await _context.SaveChangesAsync();
                return new Response { Message = $"User {user.PrimerNombre} {user.PrimerApellido}  fue eliminado correctamente." };
            }
        }
}
