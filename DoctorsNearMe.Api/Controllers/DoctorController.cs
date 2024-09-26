using Microsoft.AspNetCore.Mvc;
using DoctorsNearMe.Application.Doctors.Contracts;
using DoctorsNearMe.Application.Patients;
using DoctorsNearMe.Application.Patients.Contracts;
using DoctorsNearMe.Application.Users;
using DoctorsNearMe.Application.Users.Contracts;
using DoctorsNearMe.Application.Doctors;

namespace DoctorsNearMe.Api.Controllers;

[ApiController]
[Route("api/doctor")]
public class DoctorController : ControllerBase
{
    readonly ILogger<DoctorController> _logger;
    readonly IDoctorService _doctorService;

    public DoctorController(
        ILogger<DoctorController> logger,
        IDoctorService patientService)
    {
        _logger = logger;
        _doctorService = patientService;
    }

    [HttpGet("list")]
    public async Task<IActionResult> ListDoctors()
    {
        return Ok(await _doctorService.GetAllAsync());
    }

    [HttpPost("enroll")]
    public async Task<IActionResult> EnrollUserAsDoctor(EnrollUserAsDoctorRequest request)
    {
        return Ok(await _doctorService.EnrollUserAsync(request));
    }
}
