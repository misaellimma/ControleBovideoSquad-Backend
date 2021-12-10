using ControleBovideoSquad.Application.IMapper;
using ControleBovideoSquad.Application.IMapper.Animais;
using ControleBovideoSquad.Application.IMapper.Produtores;
using ControleBovideoSquad.Application.IMapper.Propriedades;
using ControleBovideoSquad.Application.IMapper.RegistroVacinas;
using ControleBovideoSquad.Application.IMapper.Vendas;
using ControleBovideoSquad.Application.IServices.Animais;
using ControleBovideoSquad.Application.IServices.Enderecos;
using ControleBovideoSquad.Application.IServices.Produtores;
using ControleBovideoSquad.Application.IServices.Propriedades;
using ControleBovideoSquad.Application.IServices.Vacinacao;
using ControleBovideoSquad.Application.IServices.Vendas;
using ControleBovideoSquad.Application.Mapper;
using ControleBovideoSquad.Application.Mapper.Animais;
using ControleBovideoSquad.Application.Mapper.Enderecos;
using ControleBovideoSquad.Application.Mapper.Produtores;
using ControleBovideoSquad.Application.Mapper.Propriedades;
using ControleBovideoSquad.Application.Mapper.RegistroVacinas;
using ControleBovideoSquad.Application.Mapper.Vendas;
using ControleBovideoSquad.Application.Services;
using ControleBovideoSquad.Application.Services.Animais;
using ControleBovideoSquad.Application.Services.Enderecos;
using ControleBovideoSquad.Application.Services.Produtores;
using ControleBovideoSquad.Application.Services.Vendas;
using ControleBovideoSquad.Application.Validators;
using ControleBovideoSquad.Application.Validators.Endereco;
using ControleBovideoSquad.Application.Validators.Vacinacao;
using ControleBovideoSquad.CrossCutting.Dto.Enderecos;
using ControleBovideoSquad.Domain.Entities.Enderecos;
using ControleBovideoSquad.Repository.Entity;
using ControleBovideoSquad.Repository.Interfaces;
using ControleBovideoSquad.Repository.Util;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>
            options.AddPolicy("AllowAnyOrigin", builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            })
        );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IApplicationBuilder, ApplicationBuilder>();

builder.Services.AddScoped<IAnimalService, AnimalService>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IEspecieService, EspecieService>();
builder.Services.AddScoped<IFinalidadeDeVendaService, FinalidadeDeVendaService>();

builder.Services.AddScoped<IMunicipioService, MunicipioService>();
builder.Services.AddScoped<IProdutorService, ProdutorService>();
builder.Services.AddScoped<IPropriedadeService, PropriedadeService>();
builder.Services.AddScoped<IRegistroVacinaService, RegistroVacinaService>();
builder.Services.AddScoped<IRebanhoService, RebanhoService>();
builder.Services.AddScoped<ITipoDeEntradaService, TipoDeEntradaService>();
builder.Services.AddScoped<IVacinaService, VacinaService>();
builder.Services.AddScoped<IVendaService, VendaService>();

builder.Services.AddScoped<IPropriedadeMapper, PropriedadeMapper>();
builder.Services.AddScoped<MunicipioMapper, MunicipioMapper>();
builder.Services.AddScoped<IProdutorMapper, ProdutorMapper>();
builder.Services.AddScoped<IAnimalMapper, AnimalMapper>();
builder.Services.AddScoped<IRebanhoMapper, RebanhoMapper>();
builder.Services.AddScoped<IVendaMapper, VendaMapper>();
builder.Services.AddScoped<IUnityOfWork, UnityOfWork>();

builder.Services.AddScoped(typeof(IMapper<EnderecoDto, Endereco>), typeof(EnderecoMapper));
builder.Services.AddScoped(typeof(IRegistroVacinaDtoMapper), typeof(RegistroVacinaMapper));
builder.Services.AddScoped(typeof(IValidator<EnderecoDto>), typeof(EnderecoValidator));
builder.Services.AddScoped<IRegistroVacinaValidator, RegistroVacinaValidator>();

builder.Services.AddScoped<IUnityOfWork, UnityOfWork>();
builder.Services.AddSingleton<SessionFactory>();

var uowType = typeof(IUnityOfWork);
var registrosAssembly = uowType.Assembly;
var registroDeRepositorios = from type in registrosAssembly.GetExportedTypes()
                             where type.GetInterfaces().Any()
                             where !type.Namespace.StartsWith("ControleBovideoSquad.Repository.Entity") &&
                             !type.Namespace.StartsWith("ControleBovideoSquad.Repository.Interfaces") &&
                             !type.Namespace.StartsWith("ControleBovideoSquad.Repository.Mappings")
                             select new { Interface = type.GetInterfaces().Single(), Implementation = type };

registroDeRepositorios.ToList().ForEach(x => builder.Services.AddScoped(x.Interface, x.Implementation));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAnyOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
