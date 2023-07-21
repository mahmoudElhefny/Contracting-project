
using Data.Models.Solutoin_Page;
using Infrastructure.Dtos.DtoSolution.SolutionPageDto;
using Infrastructure.Repositories.ProjectRepo.ProjectRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolutionPageController : ControllerBase
    {
        private IPublicInterface<SolutionPageAddDto, solutionPage, SolutionPageInfoDto> solutionPageRepo;

        public SolutionPageController(IPublicInterface<SolutionPageAddDto, solutionPage, SolutionPageInfoDto> _solutionPageRepo)
        {
            this.solutionPageRepo = _solutionPageRepo;
        }

        [HttpPost("AddsolutionPage")]
        public IActionResult add([FromForm] SolutionPageAddDto solutionPageAddDto)
        {
            if (ModelState.IsValid)
            {
                solutionPage solutionPage = this.solutionPageRepo.Insert(solutionPageAddDto);
                if (solutionPage != null)
                    return Ok(solutionPage);

                return BadRequest();
            }
            return BadRequest(ModelState);
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(solutionPageRepo.GetAll());
        }
        [HttpGet("GetsolutionPageByID")]
        public IActionResult GetById(int id)
        {
            if (id != null)
                return Ok(this.solutionPageRepo.getById(id));
            return BadRequest("Solution Page ID is Missing");
        }

        [HttpDelete("DeletesolutionPage")]
        public IActionResult Delete(int id)
        {
            if (solutionPageRepo.Delete(id))
            {
                return StatusCode(201, "تم الحذف بنجاح");
            }
            return BadRequest("لم يتم الحذف حاول مره اخري");
        }

        [HttpPost("EditsolutionPage")]
        public IActionResult Edit(int id, [FromForm] SolutionPageAddDto Solution)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            solutionPage newsolutionPage = this.solutionPageRepo.Update(id, Solution);
            if (newsolutionPage != null)
                return Ok(newsolutionPage);
            return BadRequest();
        }
    }
}

