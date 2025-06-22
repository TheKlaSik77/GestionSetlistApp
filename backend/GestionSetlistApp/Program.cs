using GestionSetlistApp.Data;
using GestionSetlistApp.Services;
using GestionSetlistApp.Repositories;
using Microsoft.EntityFrameworkCore;

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

builder.Services.AddScoped<IMorceauxService, MorceauxService>();
builder.Services.AddScoped<IDeezerAPIService, DeezerAPIService>();
builder.Services.AddHttpClient<IDeezerAPIService, DeezerAPIService>();

builder.Services.AddScoped<IMorceauxRepository,MorceauxRepository>();

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

