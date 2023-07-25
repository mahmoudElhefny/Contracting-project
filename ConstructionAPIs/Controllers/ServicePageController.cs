using Infrastructure.Dtos;
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
        public async Task<IActionResult> GetAll(string Lang ="EN")
        {
            var res = await servicePageRepository.GetAll(Lang);
            return Ok(res);
        }

        [HttpPost("CreateService")]
        public async Task<IActionResult> InsertService([FromForm] ServiceDto dto)
        {
            if (dto.bg == null)
                return BadRequest("Poster is required!");
            var res = await servicePageRepository.InsertService(dto);
            return Ok(res);
        }

        [HttpPost("CreateServiceItem")]
        public async Task<IActionResult> InsertServiceItem([FromForm] ServiceItemDto dto)
        {
            if (dto.icon == null)
                return BadRequest("Icon is required!");
            var res = await servicePageRepository.InsertServiceItem(dto);
            return Ok(res);
        }
    }
}
