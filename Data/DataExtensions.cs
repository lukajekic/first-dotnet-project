using System;
using Microsoft.EntityFrameworkCore;
using Notes.Context;

namespace Notes.Data;

public static class DataExtensions
{
public static void MigrateDB(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var DbContext = scope.ServiceProvider.GetRequiredService<NotesContextClass>();
        DbContext.Database.Migrate();

    }

public static void AddNotesDB(this WebApplicationBuilder builder)
    {
        var connStirng = builder.Configuration.GetConnectionString("Notes");
        builder.Services.AddSqlServer<NotesContextClass>(connStirng);
    }
}
