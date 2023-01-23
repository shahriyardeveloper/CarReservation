using CarReservation.Application.Behaviours;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using CarReservation.Application.Mapper;
using CarReservation.Application.Interfaces.Services;
using CarReservation.Application.Services;

namespace CarReservation.Application.Extensions;

public static class ServiceExtensions
{
    [Obsolete]
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining(typeof(BaseValidator<>));
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IClientFacingFormService, ClientFacingFormService>();
        //services.AddScoped<IClientFacingFormService, EmployeeService>();

        services.AddFluentValidation(configuration =>
        {
            configuration.RegisterValidatorsFromAssemblyContaining<UserValidators>();
            configuration.RegisterValidatorsFromAssemblyContaining<ClientFacingFormValidators>();

        });

        services.AddAutoMapper(config =>
        {
            config.AddProfile<MappingProfile>();
        });
    }
}

