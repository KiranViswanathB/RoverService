using RoverService.Service;

using DotNetEnv;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddHttpClient("NasaApi", httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration.GetSection("NasaApi")?.GetSection("BaseUrl")?.Value ?? "");
});

builder.Services.AddScoped<INasaService, NasaService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowedOrigins",
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseCors("MyAllowedOrigins");

app.UseAuthorization();



app.MapControllers();

app.Run();
