namespace GameIndex
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);
      builder.Services.AddControllers();
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();
      builder.Services.AddSwaggerDocument();

      var app = builder.Build();
      app.UseOpenApi();
      app.UseSwaggerUi3();
      app.UseHttpsRedirection();
      app.UseAuthorization();
      app.MapControllers();

#if DEBUG
      app.UseSpa(spa =>
      {
        spa.UseProxyToSpaDevelopmentServer("http://localhost:8080");
      });
#else
      app.UseStaticFiles();
      app.MapFallbackToFile("index.html");
#endif

      app.Run();
    }
  }
}
