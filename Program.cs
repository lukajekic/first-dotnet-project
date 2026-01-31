using Notes.Data;
using Notes.Endpoints;
using Microsoft.EntityFrameworkCore.Design;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();
builder.AddNotesDB();
var app = builder.Build();
app.AddNotesEndpoints();

app.MigrateDB();
app.MapGet("/", () => "Hello World!");
app.Run();
