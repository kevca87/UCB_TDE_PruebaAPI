using Iter0_Backend.Data.Repository;
using Iter0_Backend.Services;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IKidService, KidService>();
builder.Services.AddSingleton<IAppRepository, AppRepository>();

//AutoMapper

builder.Services.AddAutoMapper(typeof(KidService));


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
