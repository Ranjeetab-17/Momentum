using Converter.ConverterRepository.Implementations;
using Converter.ConverterRepository.Interfaces;
using Converter.DataModel;
using Converter.Model;
using DataAccess.DataModels;
using Microsoft.EntityFrameworkCore;
using Models;
using static System.Runtime.InteropServices.JavaScript.JSType;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration["Data:ConnectionString:myconn"]));
builder.Services.AddTransient<IMetricToImperialConverter, MetricToImperialConverter>();

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
