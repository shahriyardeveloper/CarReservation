using CarReservation.Application.Interfaces;
using CarReservation.Application.Interfaces.Repositories;
using CarReservation.Persistence.Context;
using CarReservation.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarReservation.Persistence.Extensions;

public static class ServiceExtensions
{
    public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicatonDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));

        #region Repositories
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        #endregion Repositories
    }
}
