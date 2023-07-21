using Infrastructure.Dtos.ApplicationUsersDto;
using Infrastructure.Repositories.ApplicationUserReposatories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAppUserRepo AppRepo;
        public AccountController(IAppUserRepo appUserRepo)
        {
                this.AppRepo = appUserRepo;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm] RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                var AuthResponseData = await AppRepo.RegisetrAsync(registerDto);
                if(AuthResponseData != null)
                {
                    return Ok(AuthResponseData);
                }
                return BadRequest(AuthResponseData.Message);
            }
            return BadRequest(ModelState);
        }
    }
}
