using GameIndex.Helpers;
using GameIndex.Repos;

namespace GameIndex.Extensions;

static class ServiceCollectionExtensions
{
  public static IServiceCollection AddGameIndex(this IServiceCollection services)
  {
    return services
      .AddSingleton<IConnectionHelper, ConnectionHelper>()
      .AddSingleton<IGamesRepo, GamesRepo>();
  }
}