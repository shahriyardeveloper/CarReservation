using CarReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarReservation.Persistence.ModelConfigs;

public class ClientFacingFormConfiguration : BaseEntityConfiguration<ClientFacingForm>
{
    public override void Configure(EntityTypeBuilder<ClientFacingForm> builder)
    {
        builder.Property("Name").HasColumnType("varchar").HasMaxLength(50);
        builder.Property("BookingDate").HasColumnType("date");
        builder.Property("Flexibility").HasColumnType("int");
        builder.Property("VehicleSize").HasColumnType("int");
        builder.Property("ContactNumber").HasColumnType("varchar").HasMaxLength(15);
        builder.Property("EmailAddress").HasColumnType("varchar").HasMaxLength(50);
        builder.Property("Status").HasColumnType("int");

        base.Configure(builder);
        builder.ToTable("ClientFacingForm");
    }
}

