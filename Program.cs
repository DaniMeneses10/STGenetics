using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using STGeneticsProject.Database;
using STGeneticsProject.Interfaces;
using STGeneticsProject.Models.Validator;
using STGeneticsProject.Services;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<STGeneticsDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient, ServiceLifetime.Transient);

builder.Services.AddTransient<IAnimalService, AnimalService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IValidatorOrderAnimals, ValidatorOrderAnimals>();
builder.Services.AddTransient<IOrderAnimalService, OrderAnimalService>();

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
