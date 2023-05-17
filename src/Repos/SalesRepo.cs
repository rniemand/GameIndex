using GameIndex.Helpers;

namespace GameIndex.Repos;

public interface ISalesRepo
{
}

public class SalesRepo : ISalesRepo
{
  public const string TableName = "Sales";
  private readonly IConnectionHelper _connectionHelper;

  public SalesRepo(IConnectionHelper connectionHelper)
  {
    _connectionHelper = connectionHelper;
  }
}
