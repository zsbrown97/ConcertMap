using Microsoft.EntityFrameworkCore;

using ConcertMap.Data;
using ConcertMap.Interfaces;
using ConcertMap.Profiles;
using ConcertMap.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddControllers();

// AddScoped services here
builder.Services.AddScoped<IVenueService, VenueService>();
builder.Services.AddScoped<IConcertService, ConcertService>();
builder.Services.AddScoped<IFestivalService, FestivalService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
    );
});


// Add dbContext with SQLite
builder.Services.AddDbContext<ConcertMapContext>(options => 
    options.UseSqlite("Data Source=./concerts.db"));

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.UseCors("AllowFrontend");

app.Run();
 
