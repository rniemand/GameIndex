using GameIndex.Models.Dto;
using GameIndex.Models.Entities;
using GameIndex.Repos;

namespace GameIndex.Services;

public interface ILocationService
{
  Task<List<LocationDto>> GetLocationsAsync(int platformId);
  Task<int> SetGameLocationAsync(long gameId, int locationId);
  Task<LocationDto> AddLocationAsync(LocationDto location);
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

  public async Task<LocationDto> AddLocationAsync(LocationDto location)
  {
    var dbLocation = await _locationRepo.GetLocationByNameAsync(location.PlatformID, location.LocationName);
    if (dbLocation is not null) return LocationDto.FromEntity(dbLocation);

    var rowCount = await _locationRepo.AddLocationAsync(new LocationEntity
    {
      LocationName = location.LocationName,
      PlatformID = location.PlatformID,
    });
    if (rowCount < 0) throw new Exception("Failed to add location");

    dbLocation = await _locationRepo.GetLocationByNameAsync(location.PlatformID, location.LocationName);
    if(dbLocation is null) throw new Exception("Failed to add location");
    return LocationDto.FromEntity(dbLocation);
  }
}
