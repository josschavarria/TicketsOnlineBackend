using Microsoft.EntityFrameworkCore;
using TicketsOnlineBackend.Context;
using TicketsOnlineBackend.Helppers;
using TicketsOnlineBackend.Models;

namespace TicketsOnlineBackend.Services
{
    public class CapacidadServices
    {

        private readonly MyContext _context;

        public CapacidadServices(MyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Capacidad>> GetAll()
        {
            return await _context.Capacidad.ToListAsync();
        }

        public async Task<Response> GetById(long id)
        {
            var user = await _context.Capacidad.FirstOrDefaultAsync(r => r.Id == id);
            if (user == null)
            {
                return new Response { Message = "Capacidad no existe." };
            }

            return new Response { Data = user };
        }

        public async Task<Response> PostCapacidad(Capacidad user)
        {
            //poner para INT
            {
                return new Response { Message = "Por favor llenar los campos vacios." };
            }


            _context.Capacidad.Add(user);
            await _context.SaveChangesAsync();
            return new Response { Message = "Agregado Correctamente." };
        }

        public async Task<Response> PutCapacidad(Capacidad user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Message = "Informacion modificada existosamente" };
        }

        public async Task<Response> DeleteCapacidad(int id)
        {
            var user = await _context.Capacidad.FindAsync(id);
            if (user == null)
            {
                return "No existe Capacidad con este numero de ID.";
            }
            _context.Capacidad.Remove(user);
            await _context.SaveChangesAsync();
            return new Response { Message = $"User {user.Id}  fue eliminado correctamente." };
        }
    }
}
