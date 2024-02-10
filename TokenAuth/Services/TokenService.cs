using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TokenAuth.Dtos;
using TokenAuth.Models;

namespace TokenAuth.Services
{
    public class TokenService(IConfiguration configuration,UserManager<AppUser> userManager)
    {
        //add primary constructer configuration for read appsettings.json 
        public async Task<ResponseDto<TokenCreateResponseDto>> Create(TokenCreateDto tokenCreateDto)
        {


            var hasUser = await userManager.FindByNameAsync(tokenCreateDto.TcNo);

            var checkPassword = await userManager.CheckPasswordAsync(hasUser!, tokenCreateDto.Password);

            if (hasUser == null || !checkPassword)
            {
                return ResponseDto<TokenCreateResponseDto>.Fail("Tc Number or password is wrong");
            }


            var signatureKey = configuration.GetSection("TokenOptions")["SignatureKey"]!;
            var tokenExpireAsHour = configuration.GetSection("TokenOptions")["Expire"]!;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signatureKey));

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            

            var claimList = new List<Claim>();
            
            var userIdAsClaim=new Claim(ClaimTypes.NameIdentifier, hasUser.Id.ToString());
                                                                                                      
            var userNameAsClaim=new Claim(ClaimTypes.Name, hasUser.UserName!);

            claimList.Add(userIdAsClaim);
            claimList.Add(userNameAsClaim);

            foreach(var role in await userManager.GetRolesAsync(hasUser))
            {
                claimList.Add(new Claim(ClaimTypes.Role, role));
            }



            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(Convert.ToDouble(tokenExpireAsHour)),
                signingCredentials: signingCredentials,
                claims:claimList);

            var responseDto = new TokenCreateResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
                
            };

            return ResponseDto<TokenCreateResponseDto>.Success(responseDto);



        }
    }
}
