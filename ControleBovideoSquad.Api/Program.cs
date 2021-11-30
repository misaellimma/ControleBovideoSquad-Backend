using ControleBovideoSquad.Application.IServices;
using ControleBovideoSquad.Application.IServices.Animais;
using ControleBovideoSquad.Application.IServices.Vendas;
using ControleBovideoSquad.Application.Services;
using ControleBovideoSquad.Application.Services.Animais;
using ControleBovideoSquad.Application.Services.Vendas;
using ControleBovideoSquad.Domain.Repositories.Animais;
using ControleBovideoSquad.Domain.Repositories.Municipios;
using ControleBovideoSquad.Domain.Repositories.Vendas;
using ControleBovideoSquad.Repository.Animais;
using ControleBovideoSquad.Repository.Enderecos;
using ControleBovideoSquad.Repository.Entity;
using ControleBovideoSquad.Repository.Interfaces;
using ControleBovideoSquad.Repository.Util;
using ControleBovideoSquad.Repository.Vendas;

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
builder.Services.AddScoped<IVendaService, VendaService>();
builder.Services.AddScoped<IVendaRepository, VendaRepository>();
builder.Services.AddScoped<ITipoDeEntradaRepository, TipoDeEntradaRepository>();
builder.Services.AddScoped<ITipoDeEntradaService, TipoDeEntradaService>();
builder.Services.AddScoped<IMunicipioService, MunicipioService>();
builder.Services.AddScoped<IMunicipioRepository, MunicipioRepository>();
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
