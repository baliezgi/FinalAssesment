using Management.Service.Dtos;
using Microsoft.AspNetCore.Identity;
using Management.Repository.Models;

namespace Management.Service.Services
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
                UserName = userCreateDto.TcNo
                
            };
            var result = await UserManager.CreateAsync(user, userCreateDto.Password);
            if (!result.Succeeded)
            {
                var errorList = result.Errors.Select(x => x.Description).ToList();
                return ResponseDto<Guid>.Fail(errorList);
            }

            return ResponseDto<Guid>.Success(user.Id);
        }



        public async Task<ResponseDto<Guid>> AssignRole(RoleCreateRequestDto request)
        {
            var appRole = new AppRole
            {
                Name = request.roleName
            };


            var hasRole = await roleManager.RoleExistsAsync(appRole.Name);

            if(!hasRole)
            {
                var result = await roleManager.CreateAsync(appRole);

                if (!result.Succeeded)
                {
                    var errorList = result.Errors.Select(x => x.Description).ToList();
                    return ResponseDto<Guid>.Fail(errorList);
                }
            }

            var hasUser = await userManager.FindByIdAsync(request.userId);


            if(hasUser == null)
            {
                return ResponseDto<Guid>.Fail("User Not Found");
            }

            var roleAssignResult = await userManager.AddToRoleAsync(hasUser, appRole.Name);

            if(!roleAssignResult.Succeeded)
            {
                var errorList = roleAssignResult.Errors.Select(x => x.Description).ToList();
                return ResponseDto<Guid>.Fail(errorList);
            }

           
            

            return ResponseDto<Guid>.Success(appRole.Id);
        }
    }
}
