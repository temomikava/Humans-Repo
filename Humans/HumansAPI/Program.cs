using FluentValidation;
using FluentValidation.AspNetCore;
using HumansAPI.Data;
using HumansAPI.Models.Domain;
using HumansAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
                .AddFluentValidation(s =>
                {
                    s.ValidatorOptions.CascadeMode = CascadeMode.Stop;
                    s.ValidatorOptions.LanguageManager.Culture = new CultureInfo("en-US");
                    s.RegisterValidatorsFromAssemblyContaining<Program>();

                    // more validators
                });
//warning: type or member is absolete
//builder.Services.AddFluentValidation(opt => opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<SqlDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HumansConnectionString")));
builder.Services.AddScoped<IRepository<Human>, Repository<Human>>();
builder.Services.AddScoped<IRepository<City>, Repository<City>>();
builder.Services.AddScoped<IRepository<HumanConnection>, Repository<HumanConnection>>();
builder.Services.AddScoped<IRepository<Phone>, Repository<Phone>>();

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
