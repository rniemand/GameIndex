using GameIndex.Models;
using RnCore.Abstractions;

namespace GameIndex.Helpers;

public interface IAppPathHelper
{
  string ResolveImagePath(string path);
}

public class AppPathHelper : IAppPathHelper
{
  private readonly IPathAbstraction _path;
  private readonly string _imagesRoot;

  public AppPathHelper(IPathAbstraction path, GameIndexConfig config)
  {
    _path = path;
    _imagesRoot = _path.Join(config.ContentRootDir, "images");
  }

  public string ResolveImagePath(string path) => _path.Join(_imagesRoot, path);
}
