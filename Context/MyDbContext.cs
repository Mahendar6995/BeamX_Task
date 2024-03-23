using BeamX_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace BeamX_Task.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                .HasOne(b => b.Book)
                .WithMany(ba => ba.BookAuthors)
                .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(b => b.Author)
                .WithMany(ba => ba.BookAuthors)
                .HasForeignKey(a => a.AuthorId);

                
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set;}

        public DbSet<BookAuthor> BooksAuthors { get; set; }
    }
}
