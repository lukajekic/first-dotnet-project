using System;
using Microsoft.EntityFrameworkCore;
using Notes.Entities;

namespace Notes.Context;

public class NotesContextClass(DbContextOptions<NotesContextClass> options):DbContext(options)
{
 public DbSet<NotesEntity> Notes => Set<NotesEntity>();
}
