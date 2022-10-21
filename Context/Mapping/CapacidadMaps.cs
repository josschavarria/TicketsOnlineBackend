using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketsOnlineBackend.Models;

namespace TicketsOnlineBackend.Context.Mapping
{
    public class CapacidadMaps : IEntityTypeConfiguration<Capacidad>
    {
        public void Configure(EntityTypeBuilder<Capacidad> builder)
        {
            builder.ToTable("Capacidad", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().UseIdentityColumn();
            // builder.Property(x => x.IdCategoria).IsRequired();
            builder.Property(x => x.NumCapacidad).IsRequired().HasColumnType("decimal(10,2)");





        }


    }
}
