using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Management.Repository.Models
{
    public class AppDbContext(DbContextOptions<AppDbContext> options)
        : IdentityDbContext<AppUser, AppRole, Guid>(options)
    {

        public DbSet<Payment> Payments { get; set; } = default!;
        public DbSet<Apartment> Apartments { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Payment>()
                .HasOne(p => p.AppUser)
                .WithMany(u => u!.Payment)
                .HasForeignKey(p => p.AppUserId)
                .OnDelete(DeleteBehavior.NoAction) ;

            builder.Entity<Payment>()
                .HasOne(p => p.Apartment)
                .WithMany(a => a!.Payments)
                .HasForeignKey(p => p.ApartmentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Apartment>()
                .HasOne(a => a.AppUser)
                .WithOne(u => u!.Apartment)
                .HasForeignKey<Apartment>(a => a.AppUserId);

           
        }
    }
}
