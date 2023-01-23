using CarReservation.Domain.Common;
using CarReservation.Domain.Entities;
using CarReservation.Persistence.ModelConfigs;
using Microsoft.EntityFrameworkCore;

namespace CarReservation.Persistence.Context;

public class ApplicatonDbContext : DbContext
{
    public ApplicatonDbContext(DbContextOptions<ApplicatonDbContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public DbSet<ClientFacingForm> ClientFacingForms { get; set; }
    public DbSet<User> Users { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                    break;

                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.UtcNow;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ClientFacingFormConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}

