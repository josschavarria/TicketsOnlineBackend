using Microsoft.EntityFrameworkCore;
using TicketsOnlineBackend.Context;
using TicketsOnlineBackend.Helppers;
using TicketsOnlineBackend.Models;

namespace TicketsOnlineBackend.Services
{
    public class VendorServices
    {

        private readonly MyContext _context;

        public VendorServices(MyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vendor>> GetAll()
        {
            return await _context.Vendor.ToListAsync();
        }

        public async Task<Response> GetById(long id)
        {
            var user = await _context.Vendor.FirstOrDefaultAsync(r => r.Id == id);
            if (user == null)
            {
                return new Response { Message = "Vendor no existe." };
            }

            return new Response { Data = user };
        }

        public async Task<Response> PostVendor(Vendor user)
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


            _context.Vendor.Add(user);
            await _context.SaveChangesAsync();
            return new Response { Message = "Agregado Correctamente." };
        }

        public async Task<Response> PutVendor(Vendor user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Message = "Informacion modificada existosamente" };
        }

        public async Task<Response> DeleteVendor(int id)
        {
            var user = await _context.Vendor.FindAsync(id);
            if (user == null)
            {
                return "No existe usuario con este numero de ID.";
            }
            _context.Vendor.Remove(user);
            await _context.SaveChangesAsync();
            return new Response { Message = $"User {user.PrimerNombre} {user.PrimerApellido}  fue eliminado correctamente." };
        }
    }
}
