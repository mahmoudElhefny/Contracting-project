using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Data.Models.AppUser;
using Infrastructure.Construction_Context;
using Infrastructure.Dtos.ApplicationUsersDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Constatnts;

namespace Infrastructure.Repositories.ApplicationUserReposatories
{
    public class AppUserRepo : IAppUserRepo
    {
        private readonly UserManager<ApplicationUser> userManger;
        private readonly IConfiguration config;
        private readonly RoleManager<IdentityRole> roleManager;
     //   private readonly JWT jwt;
        private readonly ConstructionContext context;
        private readonly IMapper mapper;
        public AppUserRepo(UserManager<ApplicationUser>_userManager,ConstructionContext _context,
                           RoleManager<IdentityRole>_roleManager,IConfiguration _config,
                           IMapper _mapper
                          )
        {
            this.context = _context;
            this.roleManager = _roleManager;
            this.userManger = _userManager;
            this.config = _config;
            this.mapper = _mapper;
        }
        public async Task<AuthenticationModel> RegisetrAsync(RegisterDto userDTO)
        {
            //check if user has email registered before
            if (await userManger.FindByEmailAsync(userDTO.Email) is not null)
                return new AuthenticationModel { Message = "هذا البريد الالكتروني مستخدم من قبل" };
            //check if any user uses the same UserName
            if (await userManger.FindByNameAsync(userDTO.UserName) is not null)
                return new AuthenticationModel { Message = "اسم المستخم موجود بالفعل" };
            //create Application User
            ApplicationUser user = new ApplicationUser();

            user.UserName = userDTO.UserName;
            user.Email = userDTO.Email;
            user.PhoneNumber = userDTO.PhoneNumber;
            user.LastName = userDTO.LastName;
            user.FirstName = userDTO.FirstName;
            user.Password = userDTO.Password;
            using var dataStream = new MemoryStream();
            await userDTO.image.CopyToAsync(dataStream);
            var temp= dataStream.ToArray();
            user.image = temp;
            //   var data = mapper.Map<ApplicationUser>(userDTO);
                            //create user in database
            IdentityResult result = await userManger.CreateAsync(user, userDTO.Password);
            if (result.Succeeded)
            {
                // assign  new user to Role As user
                result = await userManger.AddToRoleAsync(user, "USER");// Roles.USER_ROLE);
                if (!result.Succeeded)
                    return new AuthenticationModel { Message = getErrorsAsString(result) };
                var jwtSecurityToken = await this.CreateJwtToken(user);
                return new AuthenticationModel
                {
                    Email = user.Email,
                    ExpiresOn = jwtSecurityToken.ValidTo,
                    IsAuthenticated = true,
                    Roles = new List<string> { Roles.USER_ROLE },
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    Username = user.UserName
                };
            }

            return new AuthenticationModel { Message = getErrorsAsString(result) };
        }

        private string getErrorsAsString(IdentityResult result)
        {
            string errors = String.Empty;
            foreach (var er in result.Errors)
            {
                errors += er.Description.ToString();
            }
            return errors;
        }

        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            //get claims
            var UserClaims = await this.userManger.GetClaimsAsync(user);

            //get Role
            var roles = await userManger.GetRolesAsync(user);
            var roleClaims = new List<Claim>();
            foreach (var role in roles)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, role));
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email)
            }.Union(UserClaims).Union(roleClaims);
            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:secret"]));
            SigningCredentials signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            //create Token
            JwtSecurityToken myToken = new JwtSecurityToken(
            issuer: config["JWT:ValidIssuer"],
            audience: config["JWT:ValidAudiance"],
            claims: claims,
            expires: DateTime.Now.AddDays(int.Parse(config["JWT:DurationInDays"])),
            signingCredentials: signingCred
         );
            return myToken;
        }
    }
}
