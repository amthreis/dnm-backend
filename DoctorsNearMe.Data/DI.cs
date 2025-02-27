﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DoctorsNearMe.Data.Entities;
using DoctorsNearMe.Data.Repositories;
using DoctorsNearMe.Data.Repositories.Interfaces;
using System.Diagnostics;
using System.Numerics;

namespace DoctorsNearMe.Data;

public static class DI
{
    public static IServiceCollection AddData(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(
                config.GetConnectionString("DefaultConnection"), 
                x => x.UseNetTopologySuite());
        });

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<IClinicRepository, ClinicRepository>();
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();

        return services;
    }
}
