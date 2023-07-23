using Data.Models.Project;
using Infrastructure.Dtos.ProjectItemsDto;
using Infrastructure.Dtos.ProjectPageDto;
using Infrastructure.Repositories.ProjectRepo.ProjectRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectItemsController : ControllerBase
    {
        private IPublicInterface<ProjectItemsAddDto, ProjectItems,ProjectItemsInfoDto> ProjectItemsRepo;

        public ProjectItemsController(IPublicInterface<ProjectItemsAddDto, ProjectItems, ProjectItemsInfoDto> _ProjectItemsRepo)
        {
            this.ProjectItemsRepo = _ProjectItemsRepo;
        }

        [HttpPost("AddProjectItems")]
        public IActionResult add([FromForm] ProjectItemsAddDto projectPageAddDto)
        {
            if (ModelState.IsValid)
            {
                ProjectItems projectPage = this.ProjectItemsRepo.Insert(projectPageAddDto);
                if (projectPage != null)
                    return Ok(projectPage);

                return BadRequest();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("DeleteProjectItems")]
        public IActionResult Delete(int id)
        {
            if (ProjectItemsRepo.Delete(id))
            {
                return StatusCode(201, "تم الحذف بنجاح");
            }
            return BadRequest("لم يتم الحذف حاول مره اخري");
        }


        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(ProjectItemsRepo.GetAll());
        }
        [HttpGet("GetProjectItemsByID")]
        public IActionResult GetById(int id)
        {
            if (id != null)
                return Ok(this.ProjectItemsRepo.getById(id));
            return BadRequest("ProjectItem  ID is Missing");
        }

        [HttpPost("EditProjectItems")]
        public IActionResult Edit(int id, [FromForm] ProjectItemsAddDto project)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            ProjectItems newProjectPage = this.ProjectItemsRepo.Update(id, project);
            if (newProjectPage != null)
                return Ok(newProjectPage);
            return BadRequest();
        }
    
}
}
