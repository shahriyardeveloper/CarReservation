using CarReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Persistence.ModelConfigs;

public class UserConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property("FirstName").HasColumnType("varchar").HasMaxLength(20);
        builder.Property("LastName").HasColumnType("varchar").HasMaxLength(20);
        builder.Property("Email").HasColumnType("varchar").HasMaxLength(50);
        builder.Property("Password").HasColumnType("varchar").HasMaxLength(1000);
        builder.Property("ConfirmPassword").HasColumnType("varchar").HasMaxLength(1000);

        base.Configure(builder);
        builder.ToTable("User");
    }
}

