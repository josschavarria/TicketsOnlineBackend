using Microsoft.EntityFrameworkCore;
using TicketsOnlineBackend.Context;
using TicketsOnlineBackend.Helppers;
using TicketsOnlineBackend.Models;

namespace TicketsOnlineBackend.Services
{
    public class TicketServices
    {

        private readonly MyContext _context;

        public TicketServices(MyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            return await _context.Ticket.ToListAsync();
        }

        public async Task<Response> GetById(long id)
        {
            var user = await _context.Ticket.FirstOrDefaultAsync(r => r.Id == id);
            if (user == null)
            {
                return new Response { Message = "Ticket no existe." };
            }

            return new Response { Data = user };
        }

        public async Task<Response> PostTicket(Ticket user)
        {

            {
                return new Response { Message = "Por favor llenar los campos vacios." };
            }


            _context.Ticket.Add(user);
            await _context.SaveChangesAsync();
            return new Response { Message = "Agregado Correctamente." };
        }

        public async Task<Response> PutTicket(Ticket user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Message = "Informacion modificada existosamente" };
        }

        public async Task<Response> DeleteTicket(int id)
        {
            var user = await _context.Ticket.FindAsync(id);
            if (user == null)
            {
                return "No existe tiket con este numero de ID.";
            }
            _context.Ticket.Remove(user);
            await _context.SaveChangesAsync();
            return new Response { Message = $"User {user.Id}  fue eliminado correctamente." };
        }

    }
}
