
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace TokenAuth.Models
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) 
        : IdentityDbContext<AppUser, AppRole, Guid>(options)
    {

        public DbSet<Payment> Payments { get; set; }=default!;


    }
}
