using GameIndex.Models.Dto;
using GameIndex.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameIndex.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationsController : ControllerBase
{
  private readonly ILocationService _locationService;

  public LocationsController(ILocationService locationService)
  {
    _locationService = locationService;
  }

  [HttpGet("list/platform-id/{platformId:int}")]
  public async Task<List<LocationDto>> GetPlatformLocations([FromRoute] int platformId) =>
    await _locationService.GetLocationsAsync(platformId);
}
