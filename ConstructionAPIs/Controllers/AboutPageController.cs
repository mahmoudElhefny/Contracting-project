using Infrastructure.Dtos;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutPageController : ControllerBase
    {
        private readonly IAboutPageRepository aboutPageRepository;
        private new List<string> _allowedExtenstions = new List<string> { ".jpg", ".png" };
        public AboutPageController(IAboutPageRepository aboutPageRepository)
        {
            this.aboutPageRepository = aboutPageRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Details()
        {
            var Lang = "EN";
            var result = await aboutPageRepository.GetAll(Lang);
            return Ok(result);

        }
        [HttpPost("CreateAbout")]

        public async Task<IActionResult> AddAbout( [FromForm] AboutDto dto)
        {
            if (dto.bg == null)
                return BadRequest("Poster is required!");

            if (!_allowedExtenstions.Contains(Path.GetExtension(dto.bg.FileName).ToLower()))
                return BadRequest("Only .png and .jpg images are allowed!");

            var result = aboutPageRepository.Insert(dto);
            return Ok(result);
        }
    }
}
