namespace TicketsOnlineBackend.Models
{
    public class Tarjeta
    {

        public int Id { get; set; }

        public string? NombreTarjeta { get; set; }

        public int NumeroTarjeta { get; set; }

        public DateTime FechaExpiracion { get; set; }

        public int CVV { get; set; }

    }
}
