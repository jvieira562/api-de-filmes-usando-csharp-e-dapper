using EnderecosAPI.Services.Interfaces;
using FilmesAPI.data.DataBaseConnection;
using FilmesAPI.data.Repository;
using FilmesAPI.data.Repository.Interfaces;
using FilmesAPI.data.UnitOfWork;
using FilmesAPI.Data.Repository;
using FilmesAPI.Data.Repository.Interfaces;
using FilmesAPI.Data.Repository.ReadRepository;
using FilmesAPI.Data.Repository.ReadRepository.Interfaces;
using FilmesAPI.Data.UnitOfWork.Interfaces;
using FilmesAPI.Services;
using FilmesAPI.Services.Interfaces;
using GerentesAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

/* DATA DI*/
builder.Services.AddScoped<DbSession>();
builder.Services.AddTransient<UnitOfWork, UnitOfWorkImpl>();
builder.Services.AddTransient<FilmeRepository, FilmeRepositoryImpl>();
builder.Services.AddTransient<CinemaRepository, CinemaRepositoryImpl>();
builder.Services.AddTransient<EnderecoRepository, EnderecoRepositoryImpl>();
builder.Services.AddTransient<GerenteRepository, GerenteRepositoryImpl>();
builder.Services.AddTransient<SessaoRepository, SessaoRepositoryImpl>();
/*SERVICE DI*/
builder.Services.AddTransient<FilmeService, FilmeServiceImpl>();
builder.Services.AddTransient<GerenteService, GerenteServiceImpl>();
builder.Services.AddTransient<EnderecoService, EnderecoServiceImpl>();
builder.Services.AddTransient<CinemaService, CinemaServiceImpl>();
builder.Services.AddTransient<SessaoService, SessaoServiceImpl>();
/*SERVICE READ DI*/
builder.Services.AddTransient<ReadSessaoRepository, ReadSessaoRepositoryImpl>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();