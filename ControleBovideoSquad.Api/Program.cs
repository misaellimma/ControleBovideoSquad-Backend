using ControleBovideoSquad.Application.IServices;
using ControleBovideoSquad.Application.Services;
using ControleBovideoSquad.Domain.Repositories.Animais;
using ControleBovideoSquad.Repository.Animais;
using ControleBovideoSquad.Repository.Entity;
using ControleBovideoSquad.Repository.Interfaces;
using ControleBovideoSquad.Repository.Util;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IApplicationBuilder, ApplicationBuilder>();
builder.Services.AddScoped<IEspecieRepository, EspecieRepository>();
builder.Services.AddScoped<IAnimalService, AnimalService>();
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<IUnityOfWork, UnityOfWork>();

builder.Services.AddSingleton<SessionFactory>();

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
