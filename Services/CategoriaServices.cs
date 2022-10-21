using Microsoft.EntityFrameworkCore;
using TicketsOnlineBackend.Context;
using TicketsOnlineBackend.Helppers;
using TicketsOnlineBackend.Models;

namespace TicketsOnlineBackend.Services
{
    public class CategoriaServices
    {

        private readonly MyContext _context;

        public CategoriaServices(MyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> GetAll()
        {
            return await _context.Categoria.ToListAsync();
        }

        public async Task<Response> GetById(long id)
        {
            var user = await _context.Categoria.FirstOrDefaultAsync(r => r.Id == id);
            if (user == null)
            {
                return new Response { Message = "Categoria no existe." };
            }

            return new Response { Data = user };
        }

        public async Task<Response> PostCategoria(Categoria user)
        {
            //poner para INT
            {
                return new Response { Message = "Por favor llenar los campos vacios." };
            }


            _context.Categoria.Add(user);
            await _context.SaveChangesAsync();
            return new Response { Message = "Agregado Correctamente." };
        }

        public async Task<Response> PutCategoria(Categoria user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Message = "Informacion modificada existosamente" };
        }

        public async Task<Response> DeleteCategoria(int id)
        {
            var user = await _context.Categoria.FindAsync(id);
            if (user == null)
            {
                return "No existe Capacidad con este numero de ID.";
            }
            _context.Categoria.Remove(user);
            await _context.SaveChangesAsync();
            return new Response { Message = $"User {user.Id}  fue eliminado correctamente." };
        }


    }
}
