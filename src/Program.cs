using GameIndex.Extensions;

namespace GameIndex;

public class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddSwaggerDocument();
    builder.Services.AddGameIndex(builder.Configuration);

    var app = builder.Build();
    app.UseOpenApi();
    app.UseSwaggerUi3();
    app.MapControllers();
    app.UseRouting();
    app.UseAuthorization();
    app.UseEndpoints(_ => { });

#if DEBUG
    app.UseSpa(spa =>
    {
      spa.UseProxyToSpaDevelopmentServer("http://localhost:3000/");
    });
#else
app.UseStaticFiles();
app.MapFallbackToFile("index.html");
#endif

    app.Run();
  }
}