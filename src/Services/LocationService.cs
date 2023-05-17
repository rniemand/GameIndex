using GameIndex.Models.Dto;
using GameIndex.Repos;

namespace GameIndex.Services;

public interface ILocationService
{
  Task<List<LocationDto>> GetLocationsAsync(int platformId);
  Task<int> SetGameLocationAsync(long gameId, int locationId);
}

public class LocationService : ILocationService
{
  private readonly ILocationRepo _locationRepo;

  public LocationService(ILocationRepo locationRepo)
  {
    _locationRepo = locationRepo;
  }

  public async Task<List<LocationDto>> GetLocationsAsync(int platformId)
  {
    var dbLocations = await _locationRepo.GetLocationsAsync(platformId);
    return dbLocations.Count == 0 ? new List<LocationDto>() : dbLocations.Select(LocationDto.FromEntity).ToList();
  }

  public async Task<int> SetGameLocationAsync(long gameId, int locationId) =>
    await _locationRepo.SetGameLocationAsync(gameId, locationId);
}
