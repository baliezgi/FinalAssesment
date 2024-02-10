using Microsoft.AspNetCore.Identity;

namespace Management.Repository.Models
{
    public class AppUser :IdentityUser<Guid> 
    {
        public string TcNo { get; set; }=default!;
    }
}
