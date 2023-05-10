using System.Data;
using MySql.Data.MySqlClient;

namespace GameIndex.Helpers;

public interface IConnectionHelper
{
  MySqlConnection GetCoreConnection();
}

public class ConnectionHelper : IConnectionHelper
{
  private readonly Dictionary<string, string> _connectionStrings = new(StringComparer.InvariantCultureIgnoreCase);

  public ConnectionHelper(IConfiguration configuration)
  {
    var section = configuration.GetSection("ConnectionStrings");
    if (!section.Exists())
      throw new Exception("Unable to find any connection strings");

    foreach (var child in section.GetChildren())
    {
      _connectionStrings[child.Key] = child.Value;
    }
  }

  public MySqlConnection GetCoreConnection() => GetNamedConnection("Core");

  private MySqlConnection GetNamedConnection(string name)
  {
    if (!_connectionStrings.ContainsKey(name))
      throw new Exception($"Unable to find connection string: {name}");

    var connection = new MySqlConnection(_connectionStrings[name]);

    if (connection.State != ConnectionState.Open)
      connection.Open();

    return connection;
  }
}