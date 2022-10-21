using Microsoft.EntityFrameworkCore;
using TicketsOnlineBackend.Context;
using TicketsOnlineBackend.Helppers;
using TicketsOnlineBackend.Models;

namespace TicketsOnlineBackend.Services
{
    public class TarjetaServices
    {

        private readonly MyContext _context;

        public TarjetaServices(MyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tarjeta>> GetAll()
        {
            return await _context.Tarjeta.ToListAsync();
        }

        public async Task<Response> GetById(long id)
        {
            var user = await _context.Tarjeta.FirstOrDefaultAsync(r => r.Id == id);
            if (user == null)
            {
                return new Response { Message = "Tarjeta no existe." };
            }

            return new Response { Data = user };
        }

        public async Task<Response> PostTarjeta(Tarjeta user)
        {
            if (string.IsNullOrEmpty(user.NombreTarjeta))


            {
                return new Response { Message = "Por favor llenar los campos vacios." };
            }


            _context.Tarjeta.Add(user);
            await _context.SaveChangesAsync();
            return new Response { Message = "Agregado Correctamente." };
        }

        public async Task<Response> PutTarjeta(Tarjeta user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Message = "Informacion modificada existosamente" };
        }

        public async Task<Response> DeleteTarjeta(int id)
        {
            var user = await _context.Tarjeta.FindAsync(id);
            if (user == null)
            {
                return "No existe Tarjeta con este numero de ID.";
            }
            _context.Tarjeta.Remove(user);
            await _context.SaveChangesAsync();
            return new Response { Message = $"User {user.NombreTarjeta} fue eliminado correctamente." };
        }
    }
}
