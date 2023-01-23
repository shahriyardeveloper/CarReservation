using CarReservation.Application.Interfaces;
using CarReservation.Persistence.Context;

namespace CarReservation.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicatonDbContext context;
    private bool disposed = false;

    public UnitOfWork(ApplicatonDbContext context)
    {
        this.context = context;
    }

    public async Task CommitAsync() => await context.SaveChangesAsync();

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
            if (disposing)
                context.Dispose();
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
