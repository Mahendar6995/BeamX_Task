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
            modelBuilder.Entity<Author>()
                .HasMany(s => s.Books)
                .WithMany(s => s.Authors)
                .UsingEntity<Dictionary<string, object>>("AuthorBooks",
                ab => ab.HasOne<Book>().WithMany().HasForeignKey("BookId"),
                ab => ab.HasOne<Author>().WithMany().HasForeignKey("AuthorId"),
                ab =>
                {
                    ab.HasKey("AuthorId", "BookId");
                    ab.ToTable("AuthorBooks");
                });
                
            base.OnModelCreating(modelBuilder);
        }
    }
}
