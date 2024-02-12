
using Business.Concrete;
using Business.DependencyResolvers;

using Core.DataAccess;
using Core.DataAccess.EntityFramework;

using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


builder.Services.RegisterBusinessServicess();


builder.Services.AddCors(options => //D��ar�dan bilmedi�in bir istek gelirse kabul et
{
    options.AddPolicy(name: "AllowAnyOrigin",
        builder => builder
        .AllowAnyOrigin() // B�t�n methodlar� kabl et
        .AllowAnyMethod()
        .AllowAnyHeader());
});

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
app.UseStaticFiles(); //resimleri ekrana getirmek i�in

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors("AllowAnyOrigin");

app.Run();
