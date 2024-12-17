

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.

//Infrastructure - EF Core
//Application - MediatR
//API - Carter, Health Checks, ... 

builder.Services
.AddApplicationServices()
.AddInfrastructureServices(builder.Configuration)
.AddApiServices();

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseApiServices();

if(app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}

app.Run();
