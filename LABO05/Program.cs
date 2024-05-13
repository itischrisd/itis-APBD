using Microsoft.EntityFrameworkCore;
using Zadanie7.Context;
using Zadanie7.Repositories;
using Zadanie7.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApbdContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<ITripsRepository, TripsRepository>();
builder.Services.AddTransient<ApbdContext, ApbdContext>();
builder.Services.AddTransient<ITripsService, TripsService>();

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
