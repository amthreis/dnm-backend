﻿using NTier.Data.Entities;
using NTier.Data.Migrations;
using System.Diagnostics;
using System.Numerics;

namespace NTier.Data;

public static class Seeders
{
    public static void Seed(this AppDbContext ctx)
    {
        Debug.WriteLine("Seeding...");

        ctx.SaveChanges();
    }

    public static void DevSeed(this AppDbContext ctx)
    {
        Debug.WriteLine("Seeding (dev)...");

        var gf = NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory(4326);

        ctx.Users.Add(new User
        {
            Name = "Leila",
            Email = "leila@m.com",
        });

        var a = new Patient
        {
            User = new User
            {
                Name = "Andreia",
                Email = "andreia@m.com",
            }
        };

        ctx.Patients.Add(a);

        var ms = new Patient
        {
            User = new User
            {
                Name = "Marcos",
                Email = "marcos@m.com",
            }
        };

        ctx.Patients.Add(ms);

        var drA = AddDoctor(ctx, new Doctor
        {
            User = new User
            {
                Name = "Alberto",
                Email = "dr.alberto@m.com",
            },
            Specialties = [DoctorSpecialty.Psychiatry]
        });

        var drL = AddDoctor(ctx, new Doctor
        {
            User = new User
            {
                Name = "Luisa",
                Email = "dra.luisa@m.com",
            },
            Specialties = [DoctorSpecialty.Dermatology, DoctorSpecialty.Pediatrics]
        });

        AddClinic(ctx, new Clinic
        {
            JuridicalPersonId = "12.345.678/0001-00",
            Name = "SESC",
            Location = gf.CreatePoint(new NetTopologySuite.Geometries.Coordinate(-43.449800391530275, -22.747648724721763)),

            Doctors = [drA, drL]
        });

        AddClinic(ctx, new Clinic
        {
            JuridicalPersonId = "12.555.678/0001-00",
            Name = "Fabinho Parabrisas",
            Location = gf.CreatePoint(new NetTopologySuite.Geometries.Coordinate(-43.43675740742485, -22.751377068032472)),
        });

        AddClinic(ctx, new Clinic
        {
            JuridicalPersonId = "10.345.111/0001-00",
            Name = "Clínica do dr. Alberto",
            Location = gf.CreatePoint(new NetTopologySuite.Geometries.Coordinate(-43.38826359022361, -22.78898601461167)),

            Doctors = [drA]
        });

        ctx.SaveChanges();
    }

    static Doctor AddDoctor(AppDbContext ctx, Doctor doctor)
    {
        var newDoctor = ctx.Doctors.Add(doctor);

        return newDoctor.Entity;
    }

    static Clinic AddClinic(AppDbContext ctx, Clinic clinic)
    {
        var newClinic = ctx.Clinics.Add(clinic);

        return newClinic.Entity;
    }
}
