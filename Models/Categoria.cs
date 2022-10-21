namespace TicketsOnlineBackend.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        public string? NombreCategoria { get; set; }

        public double PrecioCategoria { get; set; }

        public int CapacidadId { get; set; }
        public Capacidad Capacidad { get; set; }
    }
}
