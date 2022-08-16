using Iter0_Backend.Data;
using Iter0_Backend.Data.Repository;
using Iter0_Backend.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IKidService, KidService>();
builder.Services.AddTransient<IAppRepository, AppRepository>();
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => { options.AllowAnyOrigin(); options.AllowAnyMethod(); options.AllowAnyHeader(); });
});
//AutoMapper
builder.Services.AddAutoMapper(typeof(KidService));

//DB
//Change from .NET Core 5 -> Now only needed call builder.Configuration insted of initialize IConfiguration
builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("NinosConValorDB"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(options => { options.AllowAnyOrigin(); options.AllowAnyMethod(); options.AllowAnyHeader(); });

app.UseAuthorization();

app.MapControllers();

app.Run();
