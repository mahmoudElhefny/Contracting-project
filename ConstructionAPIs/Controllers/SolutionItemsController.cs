using Data.Models.Project;
using Data.Models.Solutoin_Page;
using Infrastructure.Dtos.DtoSolution.SolutionItemsDto;
using Infrastructure.Dtos.ProjectItemsDto;
using Infrastructure.Repositories.ProjectRepo.ProjectRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolutionItemsController : ControllerBase
    {
        private IPublicInterface<SolutionItemsAddDto, solutionItems, SolutionItemsInfoDto> solutionItemsRepo;

        public SolutionItemsController(IPublicInterface<SolutionItemsAddDto, solutionItems, SolutionItemsInfoDto> _solutionItemsRepo)
        {
            this.solutionItemsRepo = _solutionItemsRepo;
        }

        [HttpPost("AddsolutionItems")]
        public IActionResult add([FromForm] SolutionItemsAddDto solutionPageAddDto)
        {
            if (ModelState.IsValid)
            {
                solutionItems solutionPage = this.solutionItemsRepo.Insert(solutionPageAddDto);
                if (solutionPage != null)
                    return Ok(solutionPage);

                return BadRequest();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("DeletesolutionItems")]
        public IActionResult Delete(int id)
        {
            if (solutionItemsRepo.Delete(id))
            {
                return StatusCode(201, "تم الحذف بنجاح");
            }
            return BadRequest("لم يتم الحذف حاول مره اخري");
        }


        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(solutionItemsRepo.GetAll());
        }
        [HttpGet("GetsolutionItemsByID")]
        public IActionResult GetById(int id)
        {
            if (id != null)
                return Ok(this.solutionItemsRepo.getById(id));
            return BadRequest("ProjectItem  ID is Missing");
        }

        [HttpPost("EditsolutionItems")]
        public IActionResult Edit(int id, [FromForm] SolutionItemsAddDto project)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            solutionItems newProjectPage = this.solutionItemsRepo.Update(id, project);
            if (newProjectPage != null)
                return Ok(newProjectPage);
            return BadRequest();
        }

    }
}

