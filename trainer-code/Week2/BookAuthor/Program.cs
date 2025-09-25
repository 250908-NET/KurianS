


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
if(app.Environment.IsDevelopement())

{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Root endpoint
app.MapGet("/", () => "Hello world!");

// Run on all network interfaces, port 5000
app.Run("http://localhost:5000");




