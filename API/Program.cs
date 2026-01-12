var builder = WebApplication.CreateBuilder(args);

// do stuff like adding services/controllers
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
