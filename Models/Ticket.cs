namespace TicketsOnlineBackend.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public double Precio { get; set; }

        public int Cantidad { get; set; }

        public double Impuesto { get; set; }

        public int EventoId { get; set; }

        public Evento Evento { get; set; }

    }
}
