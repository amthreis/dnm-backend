﻿using NetTopologySuite.Geometries;
using DoctorsNearMe.Data.Entities;

namespace DoctorsNearMe.Application.Clinics.Dtos;

public record PublicClinicNearMeDto(
    Guid Id,
    string Name,
    double Distance)
{
    public static PublicClinicNearMeDto FromEntity(Clinic clinic, Point from)
    {
        return new PublicClinicNearMeDto(
            clinic.User.PublicId,
            clinic.Name,
            clinic.GetMetersTo(from) / 1000);
    }
}