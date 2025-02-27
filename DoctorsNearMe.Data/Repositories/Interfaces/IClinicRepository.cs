﻿using DoctorsNearMe.Data.Entities;
using NetTopologySuite.Geometries;

namespace DoctorsNearMe.Data.Repositories.Interfaces;

public interface IClinicRepository
{
    Task<Clinic> AddAsync(Clinic clinic);
    Task<List<Clinic>> GetAllAsync();
    Task<Clinic?> GetByUserPublicIdAsync(Guid clinicPublicId);
    Task<Clinic?> GetByJuridicalPersonId(string jpId);
    Task<List<Clinic>> GetNearCoord(Point pt, int pageSize, int page);
}
