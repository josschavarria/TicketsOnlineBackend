namespace TicketsOnlineBackend.Models
{
    public class Vendor
    {
        public int Id { get; set; }

        public string? PrimerNombre { get; set; }

        public string? SegundoNombre { get; set; }

        public string? PrimerApellido { get; set; }

        public string? SegundoApellido { get; set; }

        public string? Email { get; set; }

        public string? EmailConfirmacion { get; set; }

        public string? Clave { get; set; }

        public string? ClaveConfirmacion { get; set; }

        public string? Pais { get; set; }

        public string? Departamento { get; set; }

        public int Rtn { get; set; }

    }
}
