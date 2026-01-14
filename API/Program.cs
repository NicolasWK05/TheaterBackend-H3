using Scalar.AspNetCore;
// using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


// do stuff like adding services/controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.UseAuthorization();
app.MapControllers();

app.Run();
