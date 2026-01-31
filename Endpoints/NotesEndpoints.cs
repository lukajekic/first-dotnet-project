using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Notes.Context;
using Notes.DTOs;
using Notes.Entities;

namespace Notes.Endpoints;

public static class NotesEndpoints
{
public static void AddNotesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/notes");
        //GET - All
        group.MapGet("/", async (NotesContextClass dbContext) =>
        {
           var items = await dbContext.Notes.ToListAsync();
           return Results.Ok(items);
        });

        //GET - Id
        group.MapGet("/{id}", async (int id, NotesContextClass dbContext) =>
        {
            var item = await dbContext.Notes.FindAsync(id);
            return Results.Ok(item);
        });

        // POST - New
        group.MapPost("/", async (CreateDTO newItem, NotesContextClass dbContext) =>
        {
            NotesEntity toInsert = new()
            {
                title = newItem.title,
                description = newItem.description,
                duedate = newItem.duedate
            };

            dbContext.Notes.Add(toInsert);
            await dbContext.SaveChangesAsync();
            return Results.Ok(newItem);
        });

        group.MapPut("/{id}", async (int id, CreateDTO updatedItem, NotesContextClass dbContext) =>
        {
           var item = await dbContext.Notes.FindAsync(id);
           if (item == null)
            {
                return Results.NotFound();
            }
           item.title = updatedItem.title; 
           item.description = updatedItem.description;
           item.duedate = updatedItem.duedate;

           await dbContext.SaveChangesAsync();
           return Results.Ok();
        });

        group.MapDelete("/{id}", async (int id, NotesContextClass dbContext) =>
        {
           var item = await dbContext.Notes.FindAsync(id);
           if (item == null)
            {
                return Results.NotFound();
            } 

    
            dbContext.Notes.Remove(item);
            await dbContext.SaveChangesAsync();
            return Results.Ok();
        });
    }
}
