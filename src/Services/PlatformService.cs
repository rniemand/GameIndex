using GameIndex.Models.Dto;
using GameIndex.Repos;

namespace GameIndex.Services;

public interface IPlatformService
{
  Task<List<PlatformDto>> GetAllAsync();
}

public class PlatformService : IPlatformService
{
  private readonly IPlatformsRepo _platformsRepo;

  public PlatformService(IPlatformsRepo platformsRepo)
  {
    _platformsRepo = platformsRepo;
  }

  public async Task<List<PlatformDto>> GetAllAsync()
  {
    var dbPlatforms = await _platformsRepo.GetAllPlatformsAsync();
    return dbPlatforms.Select(PlatformDto.FromEntity).ToList();
  }
}
