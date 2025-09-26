
using Microsoft.EntityFrameworkCore;
using BookAuthor.Data;
using BookAuthor.Models;
using Serilog;



var builder = WebApplication.CreateBuilder(args);

string CS = File.ReadAllText("../connection_string.env");

// Add services to the container.

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BookAuthorDbContext>(options => options.UseSqlServer(CS));
builder.
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();   // read from appsettings.json
builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
Log.Information("Application starting...");


app.MapGet("/", () =>
{
    Log.Information("Hello world endpoint hit");
    return "Hello world";
});

app.Run();

