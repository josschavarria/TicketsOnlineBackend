using Microsoft.EntityFrameworkCore;
using TicketsOnlineBackend.Context;
using TicketsOnlineBackend.Helppers;
using TicketsOnlineBackend.Models;

namespace TicketsOnlineBackend.Services
{
    public class EventoServices
    {

        private readonly MyContext _context;

        public EventoServices(MyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Evento>> GetAll()
        {
            return await _context.Evento.ToListAsync();
        }

        public async Task<Response> GetById(long id)
        {
            var user = await _context.Evento.FirstOrDefaultAsync(r => r.Id == id);
            if (user == null)
            {
                return new Response { Message = "Evento no existe." };
            }

            return new Response { Data = user };
        }

        public async Task<Response> PostEvento(Evento user)
        {
            if (string.IsNullOrEmpty(user.NombreEvento)
                || string.IsNullOrEmpty(user.DireccionEvento) || string.IsNullOrEmpty(user.CiudadEvento)
                || string.IsNullOrEmpty(user.DepartamentoEvento) || string.IsNullOrEmpty(user.PaisEvento)
                || string.IsNullOrEmpty(user.UbicacionEvento) || string.IsNullOrEmpty(user.DescripcionEvento)
                )
            {
                return new Response { Message = "Por favor llenar los campos vacios." };
            }


            _context.Evento.Add(user);
            await _context.SaveChangesAsync();
            return new Response { Message = "Agregado Correctamente." };
        }

        public async Task<Response> PutEvento(Evento user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Message = "Informacion modificada existosamente" };
        }

        public async Task<Response> DeleteEvento(int id)
        {
            var user = await _context.Evento.FindAsync(id);
            if (user == null)
            {
                return "No existe evento con este numero de ID.";
            }
            _context.Evento.Remove(user);
            await _context.SaveChangesAsync();
            return new Response { Message = $"User {user.NombreEvento}  fue eliminado correctamente." };
        }

    }
}
