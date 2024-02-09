using Microsoft.AspNetCore.Identity;

namespace TokenAuth.Models
{
    public class AppUser :IdentityUser<Guid> 
    {
        public string TcNo { get; set; }=default!;
    }
}
