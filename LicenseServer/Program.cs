using LicenseServer.Application.Interfaces;
using LicenseServer.Domain;
using LicenseServer.Infrastructure;
using LicenseServer.Application;
using LicenseServer.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();


services.AddInfrastructure().AddApplication();

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
