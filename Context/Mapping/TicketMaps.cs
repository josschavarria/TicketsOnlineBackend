using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketsOnlineBackend.Models;

namespace TicketsOnlineBackend.Context.Mapping
{
    public class TicketMaps : IEntityTypeConfiguration<Ticket>
    {

        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("Ticket", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().UseIdentityColumn();
            builder.Property(x => x.Precio).IsRequired().HasColumnType("decimal(10,2)");
            builder.Property(x => x.Cantidad).IsRequired().HasColumnType("int");
            builder.Property(x => x.Impuesto).IsRequired().HasColumnType("decimal(10,2)");



        }
    }
}
