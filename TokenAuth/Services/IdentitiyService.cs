using Microsoft.AspNetCore.Identity;
using TokenAuth.Dtos;
using TokenAuth.Models;

namespace TokenAuth.Services
{
    public class IdentitiyService(
        UserManager<AppUser> userManager,
        RoleManager<AppRole> roleManager)
    {

        public UserManager<AppUser> UserManager { get; set; }=userManager;

        public RoleManager<AppRole> RoleManager { get; set; }=roleManager;




        public async Task<ResponseDto<Guid>> CreateUser(UserCreateDto userCreateDto)
        {
            var user = new AppUser
            {
                TcNo = userCreateDto.TcNo,

                PhoneNumber = userCreateDto.PhoneNumber,
                UserName = userCreateDto.UserName
                
            };
            var result = await UserManager.CreateAsync(user, userCreateDto.Password);
            if (!result.Succeeded)
            {
                var errorList = result.Errors.Select(x => x.Description).ToList();
                return ResponseDto<Guid>.Fail(errorList);
            }

            return ResponseDto<Guid>.Success(user.Id);
        }
    }
}
