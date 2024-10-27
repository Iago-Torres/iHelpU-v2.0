using iHelpU.MODEL.Models;
using iHelpU.MODEL.Repositories;
using iHelpU.MODEL.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'Identity_ContextConnection' not found.");
builder.Services.AddDbContext<BancoTccContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Ajuste a string de conex�o conforme necess�rio

// Registrar os servi�os no cont�iner de depend�ncia

// CompetenciaService e RepositoryCompetencia
builder.Services.AddScoped<CompetenciaService>();
builder.Services.AddScoped<RepositoryCompetencia>();

// UsuarioService e RepositoryUsuario
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<RepositoryUsuario>();

// AnuncioServicoService e RepositoryAnuncioServico
builder.Services.AddScoped<AnuncioServico_Service>();
builder.Services.AddScoped<RepositoryAnuncioServico>();

// ContratacaoServicoService e RepositoryContratacaoServico
builder.Services.AddScoped<ContratacaoServicoService>();
builder.Services.AddScoped<RepositoryContratacaoServico>();

// AvaliacaoService e RepositoryAvaliacao
builder.Services.AddScoped<Avaliacao_Service>();
builder.Services.AddScoped<RepositoryAvaliacao>();

// Adicionar os servi�os padr�o do ASP.NET Core (controladores, etc.)
builder.Services.AddControllers();

// Outras configura��es padr�o (CORS, autentica��o, etc.)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Constr�i e executa o aplicativo
var app = builder.Build();

// Outras configura��es (configura��o de middleware, etc.)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
// Add services to the container.
builder.Services.AddDbContext<BancoTccContext>(opt => opt.UseSqlServer(connectionString));
//builder.Services.AddDbContext<Identity_Context>(opt => opt.UseSqlServer(connectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
