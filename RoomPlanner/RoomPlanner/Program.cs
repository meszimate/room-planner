using Microsoft.OpenApi.Models;
using RoomPlanner.RoomPlanner.Data;
using RoomPlanner.RoomPlanner.Data.Interfaces;
using RoomPlanner.RoomPlanner.Repository;
using RoomPlanner.RoomPlanner.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddScoped<IFurnitureController>();
builder.Services.AddScoped<IRoomData, RoomData>();
builder.Services.AddScoped<IFurnitureData, FurnitureData>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "RoomPlanner API",
        Version = "v1",
        Description = "RoomPlanner API tutorial using MongoDB",
    });
});

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
