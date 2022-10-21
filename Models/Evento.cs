using System.Numerics;

namespace TicketsOnlineBackend.Models
{
    public class Evento
    {
        public int Id { get; set; }

        public string? NombreEvento { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public DateTime HoraInicio { get; set; }

        public DateTime HoraFin { get; set; }

        public string? DireccionEvento { get; set; }

        public string? CiudadEvento { get; set; }

        public string? DepartamentoEvento { get; set; }

        public string? PaisEvento { get; set; }

        public string? UbicacionEvento { get; set; }

        public string? ImagenEvento { get; set; }

        public bool EstatusEvento { get; set; }


        public string? DescripcionEvento { get; set; }

        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }

        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public int VendorId { get; set; }

        public Vendor Vendor { get; set; }


    }
}
