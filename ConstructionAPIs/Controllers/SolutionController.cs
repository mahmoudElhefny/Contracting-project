
using Data.Models.Solutoin_Page;
using Infrastructure.Dtos.DtoSolution.SolutionDto;
using Infrastructure.Repositories.ProjectRepo.ProjectRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolutionController : ControllerBase
    {
        private IPublicInterface<SolutionAddDto, solution, SolutionInfoDto> solutionRepo;

        public SolutionController(IPublicInterface<SolutionAddDto, solution, SolutionInfoDto> _solutionRepo)
        {
            this.solutionRepo = _solutionRepo;
        }

        [HttpPost("Addsolution")]
        public IActionResult add([FromForm] SolutionAddDto SolutionAddDto)
        {
            if (ModelState.IsValid)
            {
                this.solutionRepo.Insert(SolutionAddDto);

                return Ok(SolutionAddDto);
                return BadRequest();
            }
            return BadRequest(ModelState);
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {

            return Ok(solutionRepo.GetAll());
        }


        [HttpDelete("Deletesolution")]
        public IActionResult Delete(int id)
        {
            if (solutionRepo.Delete(id))
            {
                return StatusCode(201, "تم الحذف بنجاح");
            }
            return BadRequest("لم يتم الحذف حاول مره اخري");
        }
        [HttpGet("GetsolutionPageByID")]
        public IActionResult GetById(int id)
        {
            if (id != null)
                return Ok(this.solutionRepo.getById(id));
            return BadRequest("solution Page ID is Missing");
        }

        [HttpPost("EditsolutionPage")]
        public IActionResult Edit(int id, [FromForm] SolutionAddDto solution)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var res = this.solutionRepo.Update(id, solution);
            if (res != null)
                return Ok(res);
            return BadRequest();
        }
    }
}

