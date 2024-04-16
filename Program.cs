using RoverService.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddHttpClient("NasaApi", httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration.GetSection("NasaApi")?.GetSection("BaseUrl")?.Value ?? "");
});

builder.Services.AddScoped<INasaService, NasaService>();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
