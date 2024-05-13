using Microsoft.EntityFrameworkCore;
using Zadanie7.Context;
using Zadanie7.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ITripsRepository, TripsRepository>();
builder.Services.AddTransient<DbContext, ApbdContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
