using Infrastructure.Dtos;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace ConstructionAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentPageController : ControllerBase
    {
        private readonly IContentPageRepository _contentPageRepository;

        public ContentPageController(IContentPageRepository contentPageRepository)
        {
            _contentPageRepository = contentPageRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(string Lang="EN")
         {
            var result = await _contentPageRepository.GetAll(Lang);
            return Ok(result);
        }

        [HttpPost("CreateContent")]
        public async Task<IActionResult> InsertContent([FromForm] ContentDto dto)
        {
            if (dto.bg == null)
                return BadRequest("Poster is required!");
            var result = await _contentPageRepository.InsertContent(dto);
            return Ok(result);
        }

        [HttpPost("CreateItem")]
        public async Task<IActionResult> InsertItem([FromForm] ContentItemDto dto)
        {
            if (dto.image == null)
                return BadRequest("Poster is required!");
            var result = await _contentPageRepository.InsertItem(dto);
            return Ok(result);
        }
    }
}