using LicenseServer.Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;
//Hello
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var connectionString = configuration.GetConnectionString("Connection");
services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Hello World!");
app.MapDefaultControllerRoute();

app.Run();
