using Microsoft.AspNetCore.Mvc;
using NTier.Application.Clinics;
using NTier.Application.Clinics.Contracts;
using NTier.Application.Clinics.Utils;
using System.ComponentModel;

namespace NTier.Api.Controllers;

[ApiController]
[Route("api/clinic")]
public class ClinicController : ControllerBase
{
    const int PageSize = 10;

    readonly ILogger<ClinicController> _logger;
    readonly IClinicService _clinicService;

    public ClinicController(
        ILogger<ClinicController> logger,
        IClinicService clinicService)
    {
        _logger = logger;
        _clinicService = clinicService;
    }

    [HttpGet("list")]
    public async Task<IActionResult> ListClinics()
    {
        return Ok(await _clinicService.GetAllAsync());
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateClinic(CreateClinicRequest request)
    {
        return Ok(await _clinicService.CreateAsync(request));
    }

    [HttpGet("get-by-juridical-person-id/{id}")]
    public async Task<IActionResult> GetClinicByJuridicalPersonId(string id)
    {
        return Ok(await _clinicService.GetByJuridicalPersonIdAsync(id));
    }


    [HttpGet("near-me")]
    public async Task<IActionResult> FindClinicsNearMe(
            [FromQuery] LongLat longLat,
            [FromQuery][DefaultValue(1)] int page = 1)
    {
        var clinics = await _clinicService.GetNearCoord(longLat, PageSize, page);

        return Ok(clinics);
    }
}
