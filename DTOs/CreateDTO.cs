using System;

namespace Notes.DTOs;

public class CreateDTO
{
public required string title {get; set;}
public string? description {get; set;}
public DateOnly duedate {get; set;}
}
