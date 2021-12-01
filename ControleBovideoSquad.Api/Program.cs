using ControleBovideoSquad.Application.IServices;
using ControleBovideoSquad.Application.IServices.Animais;
using ControleBovideoSquad.Application.IServices.Vendas;
using ControleBovideoSquad.Application.Services;
using ControleBovideoSquad.Application.Services.Animais;
using ControleBovideoSquad.Application.Services.Vendas;
using ControleBovideoSquad.Domain.Repositories.Animais;
using ControleBovideoSquad.Domain.Repositories.Municipios;
using ControleBovideoSquad.Domain.Repositories.Vendas;
using ControleBovideoSquad.Domain.Repositories.Vacinas;
using ControleBovideoSquad.Repository.Animais;
using ControleBovideoSquad.Repository.Enderecos;
using ControleBovideoSquad.Repository.Entity;
using ControleBovideoSquad.Repository.Interfaces;
using ControleBovideoSquad.Repository.Util;
using ControleBovideoSquad.Repository.Vendas;
using ControleBovideoSquad.Repository.Vacinas;
using ControleBovideoSquad.Domain.Repositories.Produtores;
using ControleBovideoSquad.Repository.Produtores;
using ControleBovideoSquad.Application.IMapper.Produtores;
using ControleBovideoSquad.Domain.Repositories.Propriedades;
using ControleBovideoSquad.Repository.Propriedades;
using ControleBovideoSquad.Application.Mapper;
using ControleBovideoSquad.Application.Mapper.Produtores;
using ControleBovideoSquad.Application.IMapper.Animais;
using ControleBovideoSquad.Application.Mapper.Animais;

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
builder.Services.AddScoped<IRebanhoRepository, RebanhoRepository>();
builder.Services.AddScoped<IRebanhoService, RebanhoService>();
builder.Services.AddScoped<IFinalidadeDeVendaRepository, FinalidadeDeVendaRepository>();
builder.Services.AddScoped<IFinalidadeDeVendaService, FinalidadeDeVendaService>();
builder.Services.AddScoped<IVendaService, VendaService>();
builder.Services.AddScoped<IVendaRepository, VendaRepository>();
builder.Services.AddScoped<ITipoDeEntradaRepository, TipoDeEntradaRepository>();
builder.Services.AddScoped<ITipoDeEntradaService, TipoDeEntradaService>();
builder.Services.AddScoped<IMunicipioService, MunicipioService>();
builder.Services.AddScoped<MunicipioMapper, MunicipioMapper>();
builder.Services.AddScoped<IMunicipioRepository, MunicipioRepository>();
builder.Services.AddScoped<IVacinaRepository, VacinaRepository>();
builder.Services.AddScoped<IVacinaService, VacinaService>();
builder.Services.AddScoped<IProdutorService, ProdutorService>();
builder.Services.AddScoped<IProdutorMapper, ProdutorMapper>();
builder.Services.AddScoped<IAnimalMapper, AnimalMapper>();
builder.Services.AddScoped<IRebanhoMapper, RebanhoMapper>();
builder.Services.AddScoped<IProdutorRepository, ProdutorRepository>();
builder.Services.AddScoped<IPropriedadeRepository, PropriedadeRepository>();
builder.Services.AddScoped<IPropriedadeService, PropriedadeService>();
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
