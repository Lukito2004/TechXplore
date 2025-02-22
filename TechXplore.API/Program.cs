using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TechXplore.Persistence.Context;
using TechXplore.Persistence;
using TechXplore.API.Infrastructure.Mapping;
using FluentValidation;
using TechXplore.Persistence.seed;
using View.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServices();

builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection(nameof(ConnectionStrings)));

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<TechXploreDBContext>(options => options
    .UseSqlServer(builder.Configuration.GetConnectionString(nameof(ConnectionStrings.DefaultConnection)))
    .EnableSensitiveDataLogging());

builder.Services.RegisterMaps();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//TechXploreSeed.Initialize(app.Services);

app.Run();
