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


    }
}
