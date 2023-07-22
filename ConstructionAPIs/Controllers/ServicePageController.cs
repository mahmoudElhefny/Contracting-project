using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicePageController : ControllerBase
    {
        private readonly IServicePageRepository servicePageRepository;

        public ServicePageController(IServicePageRepository servicePageRepository)
        {
            this.servicePageRepository = servicePageRepository;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(string Lang)
        {
            var res = await servicePageRepository.GetAll(Lang);
            return Ok(res);
        }
    }
}
