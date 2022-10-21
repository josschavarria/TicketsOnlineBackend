using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketsOnlineBackend.Models;

namespace TicketsOnlineBackend.Context.Mapping
{
    public class EventoMaps : IEntityTypeConfiguration<Evento>
    {

        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.ToTable("Evento", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().UseIdentityColumn();
            builder.Property(x => x.NombreEvento).IsRequired().HasColumnType("varchar(max)");
            builder.Property(x => x.FechaInicio).IsRequired().HasColumnType("date");
            builder.Property(x => x.FechaFin).IsRequired().HasColumnType("date");
            builder.Property(x => x.HoraInicio).IsRequired().HasColumnType("date");
            builder.Property(x => x.HoraFin).IsRequired().HasColumnType("date");
            builder.Property(x => x.DireccionEvento).IsRequired().HasColumnType("varchar(max)");
            builder.Property(x => x.CiudadEvento).IsRequired().HasColumnType("varchar(max)");
            builder.Property(x => x.DepartamentoEvento).IsRequired().HasColumnType("varchar(max)");
            builder.Property(x => x.PaisEvento).IsRequired().HasColumnType("varchar(max)");
            builder.Property(x => x.UbicacionEvento).IsRequired().HasColumnType("varchar(max)");
            builder.Property(x => x.PaisEvento).IsRequired().HasColumnType("varchar(max)");
            builder.Property(x => x.ImagenEvento).HasColumnType("varchar(max)");
            builder.Property(x => x.EstatusEvento).HasColumnType("byte");
            builder.Property(x => x.DescripcionEvento).IsRequired().HasColumnType("varchar(max)");
        }
    }
}
