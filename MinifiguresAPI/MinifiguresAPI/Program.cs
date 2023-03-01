global using MinifiguresAPI.Models;
global using MinifiguresAPI.Data;
global using MinifiguresAPI.Services;
global using Microsoft.AspNetCore.Mvc;
global using AutoMapper;
using MinifiguresAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<IBoardGameService, BoardGameService>();
builder.Services.AddScoped<IBoardGameRepository, BoardGameRepository>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddCors(options => options.AddPolicy(name: "BoardGameOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("BoardGameOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
