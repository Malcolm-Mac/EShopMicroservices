using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.

//Infrastructure - EF Core
//Application - MediatR
//API - Carter, Health Checks, ... 

builder.Services
.AddApplicationServices()
.AddInfrustructureServices(builder.Configuration)
.AddApiServices();

var app = builder.Build();

// Configure the HTTP request pipeline

app.Run();
