using Microsoft.AspNetCore.Mvc;
using DoctorsNearMe.Application.Patients;
using DoctorsNearMe.Application.Patients.Contracts;
using DoctorsNearMe.Application.Users;
using DoctorsNearMe.Application.Users.Contracts;

namespace DoctorsNearMe.Api.Controllers;

[ApiController]
[Route("api/patient")]
public class PatientController : ControllerBase
{
    readonly ILogger<PatientController> _logger;
    readonly IPatientService _patientService;

    public PatientController(
        ILogger<PatientController> logger,
        IPatientService patientService)
    {
        _logger = logger;
        _patientService = patientService;
    }

    [HttpGet("list")]
    public async Task<IActionResult> ListPatients()
    {
        return Ok(await _patientService.GetAllAsync());
    }

    [HttpPost("enroll")]
    public async Task<IActionResult> EnrollUserAsPatient(EnrollUserAsPatientRequest request)
    {
        return Ok(await _patientService.EnrollUserAsync(request));
    }
}
