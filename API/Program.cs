using Microsoft.EntityFrameworkCore;
using TheaterBackend.Application.Interfaces;
using TheaterBackend.Application.Services;
using TheaterBackend.Domain.Interfaces;
using TheaterBackend.Infrastructure;
using TheaterBackend.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

builder.Services.AddScoped<IPersonRepo, PersonRepository>();
builder.Services.AddScoped<IFilmRepo, FilmRepo>();
builder.Services.AddScoped<IScreeningRepo, ScreeningRepo>();
builder.Services.AddScoped<IScreenRepo, ScreenRepo>();
builder.Services.AddScoped<ISeatRepo, SeatRepo>();
builder.Services.AddScoped<IShowcaseRepo, ShowcaseRepo>();
builder.Services.AddScoped<ITheaterRepo, TheaterRepo>();
builder.Services.AddScoped<ITicketRepo, TicketRepo>();

builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<FilmService>();
builder.Services.AddScoped<ScreeningService>();
builder.Services.AddScoped<ScreenService>();
builder.Services.AddScoped<SeatService>();
builder.Services.AddScoped<ShowcaseService>();
builder.Services.AddScoped<TheaterService>();
builder.Services.AddScoped<TicketService>();

builder.Services.AddScoped<IJwtTokenService>(_ =>
    new JwtTokenService(
        builder.Configuration["Jwt:Secret"]!,
        builder.Configuration["Jwt:Issuer"]!,
        builder.Configuration["Jwt:Audience"]!
    ));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseAuthorization();
app.MapControllers();
app.Run();
