using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketsOnlineBackend.Models;

namespace TicketsOnlineBackend.Context.Mapping
{
    public class VendorMaps : IEntityTypeConfiguration<Vendor>
    {

        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.ToTable("Vendor", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().UseIdentityColumn();
            builder.Property(x => x.PrimerNombre).IsRequired().HasColumnType("varchar(max)");
            builder.Property(x => x.SegundoNombre).IsRequired().HasColumnType("varchar(max)");
            builder.Property(x => x.PrimerApellido).IsRequired().HasColumnType("varchar(max)");
            builder.Property(x => x.SegundoApellido).IsRequired().HasColumnType("varchar(max)");
            builder.Property(x => x.Email).IsRequired().HasColumnType("varchar(max)");
            builder.Property(x => x.EmailConfirmacion).IsRequired().HasColumnType("varchar(max)");
            builder.Property(x => x.Clave).IsRequired().HasColumnType("varchar(max)");
            builder.Property(x => x.ClaveConfirmacion).IsRequired().HasColumnType("varchar(max)");
            builder.Property(x => x.Pais).IsRequired().HasColumnType("varchar(max)");
            builder.Property(x => x.Departamento).IsRequired().HasColumnType("varchar(max)");
            builder.Property(x => x.Rtn).IsRequired().HasColumnType("number(100)");


        }
    }
}
