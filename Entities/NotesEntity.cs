namespace Notes.Entities;

public record class NotesEntity
{
public int Id {get; set;}
public required string title {get; set;}
public  string? description {get;set;}
public DateOnly duedate {get;set;}
}
