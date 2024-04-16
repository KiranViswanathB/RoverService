var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

builder.Services.AddHttpClient("NasaApi", httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration.GetSection("NasaApi")?.GetSection("BaseUrl")?.Value ?? "");
});

app.UseAuthorization();

app.MapControllers();

app.Run();
