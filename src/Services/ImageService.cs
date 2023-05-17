using GameIndex.Helpers;
using GameIndex.Models.Dto;
using GameIndex.Repos;
using RnCore.Abstractions;

namespace GameIndex.Services;

public interface IImageService
{
  Task<string> GetGameCoverImagePathAsync(string platform, long gameId);
  Task<List<ImageDto>> GetGameImagesAsync(long gameId);
}

public class ImageService : IImageService
{
  private readonly IAppPathHelper _pathHelper;
  private readonly IImagesRepo _imagesRepo;
  private readonly IFileAbstraction _file;

  public ImageService(IAppPathHelper pathHelper,
    IImagesRepo imagesRepo,
    IFileAbstraction file)
  {
    _pathHelper = pathHelper;
    _imagesRepo = imagesRepo;
    _file = file;
  }

  public async Task<string> GetGameCoverImagePathAsync(string platform, long gameId)
  {
    var gameCoverEntity = await _imagesRepo.GetGameCoverImageAsync(gameId);
    var safePlatform = platform.ToLower();
    var fallbackPath = _pathHelper.ResolveImagePath($"covers/{safePlatform}/placeholder.png");

    if (!_file.Exists(fallbackPath))
      throw new Exception($"Unable to resolve placeholder image: {fallbackPath}");

    if (gameCoverEntity is null)
      return fallbackPath;

    var resolveImagePath = _pathHelper.ResolveImagePath(gameCoverEntity.ImagePath);

    // todo: allow for system type
    if (!_file.Exists(resolveImagePath))
      return fallbackPath;

    return resolveImagePath;
  }

  public async Task<List<ImageDto>> GetGameImagesAsync(long gameId)
  {
    var dbImages = await _imagesRepo.GetGameImagesAsync(gameId);
    return dbImages.Count == 0 ? new List<ImageDto>() : dbImages.Select(ImageDto.FromEntity).ToList();
  }
}
