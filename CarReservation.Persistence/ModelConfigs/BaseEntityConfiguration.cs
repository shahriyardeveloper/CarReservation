using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarReservation.Persistence.ModelConfigs;

public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : class
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey("Id");
        builder.Property<int>("Id").UseIdentityColumn();
        builder.Property("CreatedDate").HasColumnType("date");
        builder.Property("LastModifiedDate").HasColumnType("date");
        builder.Property("IsDeleted").HasColumnType("bit");
    }
}

