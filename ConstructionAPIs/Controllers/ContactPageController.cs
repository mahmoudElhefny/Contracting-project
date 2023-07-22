using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactPageController : ControllerBase
    {
        private readonly IContactPageRepository contactPageRepository;

        public ContactPageController(IContactPageRepository contactPageRepository)
        {
            this.contactPageRepository = contactPageRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get(string Lang="EN")
        {
            var res = await contactPageRepository.GetAll(Lang);
            return Ok(res);
        }
    }
}
