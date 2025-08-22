using GestionSetlistApp.Data;
using GestionSetlistApp.Services.MorceauServices;
using GestionSetlistApp.Repositories.MorceauRepositories;
using Microsoft.EntityFrameworkCore;
using GestionSetlistApp.Services.SetlistServices;
using GestionSetlistApp.Repositories.SetlistRepositories;
using GestionSetlistApp.Services.MembreServices;
using GestionSetlistApp.Repositories.MembreRepositories;
using GestionSetlistApp.Services.EvenementServices;
using GestionSetlistApp.Repositories.EvenementRepositories;
using GestionSetlistApp.Repositories.InstrumentRepositories;
using GestionSetlistApp.Services.InstrumentServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GestionSetlistDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
        ));


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllers();

// Morceau
builder.Services.AddScoped<IMorceauService, MorceauService>();
builder.Services.AddScoped<IDeezerAPIService, DeezerAPIService>();
builder.Services.AddHttpClient<IDeezerAPIService, DeezerAPIService>();
builder.Services.AddScoped<IMorceauRepository, MorceauRepository>();

// Setlist
builder.Services.AddScoped<ISetlistService, SetlistService>();
builder.Services.AddScoped<ISetlistRepository, SetlistRepository>();

// Membre
builder.Services.AddScoped<IMembreService, MembreService>();
builder.Services.AddScoped<IMembreRepository, MembreRepository>();

// Evenement
builder.Services.AddScoped<IEvenementService, EvenementService>();
builder.Services.AddScoped<IEvenementRepository, EvenementRepository>();

// Instrument
builder.Services.AddScoped<IInstrumentService, InstrumentService>();
builder.Services.AddScoped<IInstrumentRepository, InstrumentRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapControllers();

app.Run();

