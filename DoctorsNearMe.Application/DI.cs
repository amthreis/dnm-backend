using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DoctorsNearMe.Application.Clinics;
using DoctorsNearMe.Application.Doctors;
using DoctorsNearMe.Application.Patients;
using DoctorsNearMe.Application.Users;
using DoctorsNearMe.Data;

namespace DoctorsNearMe.Application;

public static class DI
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPatientService, PatientService>();
        services.AddScoped<IDoctorService, DoctorService>();
        services.AddScoped<IClinicService, ClinicService>();
        services.AddScoped<IAppointmentService, AppointmentService>();

        services.AddData(config);

        return services;
    }

}
