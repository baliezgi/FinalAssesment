using FinalAssesment.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalAssesment.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         modelBuilder.Entity<Expense>()
            .Property(e => e.Amount)
            .HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<Payment>()
            .Property(e => e.Amount)
            .HasColumnType("decimal(18, 2)");

            base.OnModelCreating(modelBuilder);
        }
    }
    
 
}
