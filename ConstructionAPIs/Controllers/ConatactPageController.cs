using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConatactPageController : ControllerBase
    {
        private readonly IContactPageRepository contactPageRepository;

        public ConatactPageController(IContactPageRepository contactPageRepository)
        {
            this.contactPageRepository = contactPageRepository;
        }

        [HttpGet("GetAll")]

        public async Task<IActionResult> Get()
        {
            var res = await contactPageRepository.GetAll();
            return Ok(res);
        }
    }
}
