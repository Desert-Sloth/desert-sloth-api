using desert.sloth.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseSqlite("Data Source=../Registrar.sqlite",
    b => b.MigrationsAssembly("desert.sloth.api"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "Desert Sloth API", 
        Version = "v1",
        Description = "An API for managing orders and catalog items in Desert Sloth",
        Contact = new OpenApiContact
        {
            Name = "Support",
            Email = "support@desertsloth.com",
            Url = new Uri("https://desertsloth.com")
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Desert Sloth API v1");
        c.RoutePrefix = string.Empty; // Makes Swagger accessible at the root URL
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();