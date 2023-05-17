using GameIndex.Helpers;
using GameIndex.Models;
using GameIndex.Repos;
using GameIndex.Services;
using RnCore.Abstractions;

namespace GameIndex.Extensions;

static class ServiceCollectionExtensions
{
  public static IServiceCollection AddGameIndex(this IServiceCollection services, IConfiguration configuration)
  {
    return services
      // Configuration
      .AddSingleton(BindGameIndexConfig(configuration))

      // Abstractions
      .AddSingleton<IPathAbstraction, PathAbstraction>()
      .AddSingleton<IFileAbstraction, FileAbstraction>()

      // Helpers
      .AddSingleton<IAppPathHelper, AppPathHelper>()
      .AddSingleton<IConnectionHelper, ConnectionHelper>()

      // Services
      .AddSingleton<IGamesService, GamesService>()
      .AddSingleton<IGameReceiptService, GameReceiptService>()
      
      // Repos
      .AddSingleton<IGamesRepo, GamesRepo>()
      .AddSingleton<IGameImagesRepo, GameImagesRepo>()
      .AddSingleton<IGamePlatformsRepo, GamePlatformsRepo>()
      .AddSingleton<IGameLocationRepo, GameLocationRepo>()
      .AddSingleton<IGamReceiptRepo, GamReceiptRepo>();
  }

  private static GameIndexConfig BindGameIndexConfig(IConfiguration configuration)
  {
    var section = configuration.GetSection("GameIndex");
    if (!section.Exists())
      throw new Exception("Unable to find 'GameIndex' configuration");

    var config = new GameIndexConfig();
    section.Bind(config);
    return config;
  }
}
