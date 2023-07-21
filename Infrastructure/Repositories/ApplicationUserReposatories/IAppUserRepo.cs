using Data.Models.AppUser;
using Infrastructure.Dtos.ApplicationUsersDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.ApplicationUserReposatories
{
    public interface IAppUserRepo
    {
        public Task<AuthenticationModel> RegisetrAsync(RegisterDto userDTO);
       // public Task<AuthenticationModel> Login(LoginDto userDto);
    }
}
