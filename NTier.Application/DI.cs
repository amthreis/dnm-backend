using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NTier.Application.Patients;
using NTier.Application.Users;
using NTier.Data;

namespace NTier.Application;

public static class DI
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPatientService, PatientService>();

        services.AddData(config);

        return services;
    }

}
