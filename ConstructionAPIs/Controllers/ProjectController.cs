using Data.Models.Project;
using Infrastructure.Dtos.ProjectDto;
using Infrastructure.Dtos.ProjectPageDto;
using Infrastructure.Repositories.ProjectRepo.ProjectRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IPublicInterface<ProjectAddDto,Project,ProjectInfoDto> projectRepo;

        public ProjectController(IPublicInterface<ProjectAddDto,Project, ProjectInfoDto> _projectRepo)
        {
            this.projectRepo = _projectRepo;
        }

        [HttpPost("AddProject")]
        public IActionResult add([FromForm] ProjectAddDto projectAddDto)
        {
            if (ModelState.IsValid)
            {
                this.projectRepo.Insert(projectAddDto);

                    return Ok(projectAddDto);
                return BadRequest();
            }
            return BadRequest(ModelState);
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {

            return Ok(projectRepo.GetAll());
        }
       

        [HttpDelete("DeleteProject")]
        public IActionResult Delete(int id)
        {
            if (projectRepo.Delete(id))
            {
                return StatusCode(201, "تم الحذف بنجاح");
            }
            return BadRequest("لم يتم الحذف حاول مره اخري");
        }
        [HttpGet("GetProjectPageByID")]
        public IActionResult GetById(int id)
        {
            if (id != null)
                return Ok(this.projectRepo.getById(id));
            return BadRequest("Project Page ID is Missing");
        }

        [HttpPost("EditProjectPage")]
        public IActionResult Edit(int id, [FromForm] ProjectAddDto project)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var res=this.projectRepo.Update(id, project);
            if(res!=null)
                return Ok(res);
            return BadRequest();
        }
    }
}
