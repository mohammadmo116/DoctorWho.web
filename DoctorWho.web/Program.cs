using DoctorWho.Db;
using DoctorWho.Db.DTOs;
using DoctorWho.Db.Repositories;
using DoctorWho.Db.Repositories.Interfaces;
using DoctorWho.web.Filters;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Configuration;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options=>options.Filters.Add<ValidationFilter>())
                .AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)
                .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<Program>()); ;


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<DoctorWhoCoreDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlServer") ?? throw new InvalidOperationException("Connection string 'sqlServer' not found.") ));

builder.Services.AddScoped<IEnemiesRepository, EnemiesRepository>();
builder.Services.AddScoped<IAuthorsRepository, AuthorsRepository>();
builder.Services.AddScoped<ICompanionsRepository, CompanionsRepository>();
builder.Services.AddScoped<IDoctorsRepository, DoctorsRepository>();
builder.Services.AddScoped<IEpisodesRepository, EpisodesRepository>();

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

app.Run();
