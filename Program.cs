using Notes.Data;
using Notes.Endpoints;
using Microsoft.EntityFrameworkCore.Design;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORS", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
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
