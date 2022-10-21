using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketsOnlineBackend.Models;

namespace TicketsOnlineBackend.Context.Mapping
{
    public class TarjetaMaps : IEntityTypeConfiguration<Tarjeta>
    {

        public void Configure(EntityTypeBuilder<Tarjeta> builder)
        {
            builder.ToTable("Tarjeta", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().UseIdentityColumn();
            builder.Property(x => x.NombreTarjeta).IsRequired().HasColumnType("varchar(max)");
            builder.Property(x => x.NumeroTarjeta).IsRequired().HasColumnType("float");
            builder.Property(x => x.CVV).IsRequired().HasColumnType("int");
            builder.Property(x => x.FechaExpiracion).IsRequired().HasColumnType("date");

        }
    }
}
