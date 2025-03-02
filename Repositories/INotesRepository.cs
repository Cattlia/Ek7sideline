
using System.Reflection.Metadata;
using E7Kont.Models;
using Microsoft.EntityFrameworkCore;

namespace E7Kont.Repositories
{
    public class INotesRepository: DbContext
    {
    public  INotesRepository(DbContextOptions<INotesRepository> options) : base(options) {}

    public DbSet<Note> Notes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Note>(EntityHandle =>
        {  
            entity.ToTable("notes");
            entity.Property(n => n.Id).HasColumnName("Id");
            entity.Property(n => n.Title).HasColumnName("Title");
            entity.Property(n => n.Content).HasColumnName("Content");
            entity.Property(n => n.IsArchived).HasColumnName("IsArchived");
            entity.Property(n => n.FolderId).HasColumnName("FolderId");
                      
            
        });
        
    }
    }
}

