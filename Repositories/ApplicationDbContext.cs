using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories;
public class ApplicationDbContext : DbContext
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=WikY;Trusted_Connection=True");
        }
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var p1 = new Post { Id = 1, Topic = "Theme1", Author = "Auteur1", Content = "Article1", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now };
        var p2 = new Post { Id = 2, Topic = "Theme2", Author = "Auteur2", Content = "Article2", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now };

        var c1 = new Comment { Id = 1, Author = "Auteur1", Content = "Commentaire1.1", PostId = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now };
        var c2 = new Comment { Id = 2, Author = "Auteur1", Content = "Commentaire1.2", PostId = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now };
        var c3 = new Comment { Id = 3, Author = "Auteur2", Content = "Commentaire2.1", PostId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now };

        modelBuilder.Entity<Post>().HasData(new List<Post> { p1, p2 });
        modelBuilder.Entity<Comment>().HasData(new List<Comment> { c1, c2, c3 });
        base.OnModelCreating(modelBuilder);
    }
}
