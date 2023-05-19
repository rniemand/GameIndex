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

  [HttpPut("set-location/game-id/{gameId:long}/location-id/{locationId:int}")]
  public async Task<int> SetGameLocation([FromRoute] long gameId, [FromRoute] int locationId) =>
    await _locationService.SetGameLocationAsync(gameId, locationId);

  [HttpPost("add")]
  public async Task<LocationDto> AddLocation([FromBody] LocationDto location) =>
    await _locationService.AddLocationAsync(location);
}
