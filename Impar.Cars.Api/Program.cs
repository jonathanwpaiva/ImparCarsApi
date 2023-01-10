using Impar.Cars.Api;
using Impar.Cars.Api.Models.UI;
using Impar.Cars.Api.Repositories;
using Impar.Cars.Api.Repositories.Interfaces;
using Impar.Cars.Api.Services;
using Impar.Cars.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var apiSettings = builder.Configuration.GetSection("ApiSettings").Get<ApiSettings>();

// Add services to the container.
builder.Services.AddScoped<IUploadImage, UploadImage>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(apiSettings.SqlServerConnectionString));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
