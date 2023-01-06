using APIAEROLINEA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<sistem21_aerolinaCBContext>(
x => x.UseMySql("server=sistemas19.com;database=sistem21_aerolinaCB;user=sistem21_carlosG;password=175l9yTr@", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.3.29-mariadb"))
);
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






