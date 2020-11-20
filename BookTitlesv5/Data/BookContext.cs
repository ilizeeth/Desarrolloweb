using BookTitles.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BookTitles.Data
{

    public class BookContext : IdentityDbContext<User> {

        public BookContext(DbContextOptions<BookContext> options)
        : base(options)
        {

        }

        public DbSet<Author> Authors {get; set;}
        public DbSet<Book_Author> Book_Authors {get; set;}
        public DbSet<BookCategory> BookCategories {get; set;}
        public DbSet<BookFormat> BookFormats {get; set;}
        public DbSet<BookTitle> BookTitles {get; set;}
        public DbSet<Category> Categories {get; set;}
        public DbSet<Publisher> publishers {get; set;}

        // Api Fluida
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Author>().ToTable("Author"); 
            modelBuilder.Entity<Book_Author>().ToTable("Book Author"); 
            modelBuilder.Entity<BookCategory>().ToTable("Book Category"); 
            modelBuilder.Entity<BookFormat>().ToTable("Book Format"); 
            modelBuilder.Entity<BookTitle>().ToTable("Book Titles"); 
            modelBuilder.Entity<Category>().ToTable("Category"); 
            modelBuilder.Entity<Publisher>().ToTable("Publisher"); 

            modelBuilder.Entity<Book_Author>().HasKey(c=> new {c.ISBN_Number, c.AuthorID});
            modelBuilder.Entity<BookCategory>().HasKey(c=> new {c.ISBN_Number, c.CategoryID});

        }
    }



}