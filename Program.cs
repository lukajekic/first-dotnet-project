using Notes.Data;
using Notes.Endpoints;
using Microsoft.EntityFrameworkCore.Design;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORS", policy =>
    {
        policy.WithOrigins("https://first-dotnet-frontend.vercel.app").AllowAnyHeader().WithMethods("GET", "POST", "PUT", "DELETE");
    });
});
builder.Services.AddValidation();
builder.AddNotesDB();

var app = builder.Build();
app.UseCors("CORS");
app.AddNotesEndpoints();

app.MigrateDB();
app.MapGet("/", () => "Hello World!");
app.Run();
