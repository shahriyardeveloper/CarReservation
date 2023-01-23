using CarReservation.Application.Interfaces.Repositories;
using CarReservation.Domain.Common;

namespace CarReservation.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task CommitAsync();
}

