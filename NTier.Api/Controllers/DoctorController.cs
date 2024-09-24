using Microsoft.AspNetCore.Mvc;
using NTier.Application.Doctors.Contracts;
using NTier.Application.Patients;
using NTier.Application.Patients.Contracts;
using NTier.Application.Users;
using NTier.Application.Users.Contracts;
using NTier.Application.Doctors;

namespace NTier.Api.Controllers;

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
