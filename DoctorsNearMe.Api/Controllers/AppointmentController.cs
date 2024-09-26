using Microsoft.AspNetCore.Mvc;
using DoctorsNearMe.Application.Clinics.Contracts;
using DoctorsNearMe.Application.Clinics.Utils;
using DoctorsNearMe.Application.Clinics;

namespace DoctorsNearMe.Api.Controllers;

[ApiController]
[Route("api/appointment")]
public class AppointmentController : ControllerBase
{
    const int PageSize = 10;

    readonly ILogger<AppointmentController> _logger;
    readonly IAppointmentService _appointmentService;

    public AppointmentController(
        ILogger<AppointmentController> logger,
        IAppointmentService appointmentService)
    {
        _logger = logger;
        _appointmentService = appointmentService;
    }

    [HttpGet("list")]
    public async Task<IActionResult> ListClinics()
    {
        return Ok(await _appointmentService.GetAllAsync());
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateClinic(CreateAppointmentRequest request)
    {
        return Ok(await _appointmentService.CreateAsync(request));
    }
}