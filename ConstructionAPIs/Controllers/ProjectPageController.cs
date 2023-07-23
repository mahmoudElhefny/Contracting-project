using Data.Models.Project;
using Infrastructure.Dtos.ProjectPageDto;
using Infrastructure.Repositories.ProjectRepo.ProjectRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace ConstructionAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectPageController : ControllerBase
    {
        private IPublicInterface<ProjectPageAddDto,ProjectPage,ProjectPageInfoDto> projectPageRepo;
        
        public ProjectPageController(IPublicInterface<ProjectPageAddDto,ProjectPage, ProjectPageInfoDto> _projectPageRepo)
        {
                this.projectPageRepo = _projectPageRepo;    
        }

        [HttpPost("AddProjectPage")]
        public IActionResult add([FromForm]ProjectPageAddDto projectPageAddDto)
        {
            if (ModelState.IsValid)
            {
                ProjectPage projectPage = this.projectPageRepo.Insert(projectPageAddDto);
                if(projectPage != null)
                return Ok(projectPage);

                return BadRequest();
            }
            return BadRequest(ModelState);
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(projectPageRepo.GetAll());
        }
        [HttpGet("GetProjectPageByID")]
        public  IActionResult GetById(int id)
        {
            if (id != null)
                return Ok(this.projectPageRepo.getById(id));
            return BadRequest("Project Page ID is Missing");
        }

        [HttpDelete("DeleteProjectPage")]
        public IActionResult Delete(int id)
        {
            if(projectPageRepo.Delete(id))
            {
                return StatusCode(201,"تم الحذف بنجاح");
            }
            return BadRequest("لم يتم الحذف حاول مره اخري");
        }

        [HttpPost("EditProjectPage")]
        public IActionResult Edit(int id,[FromForm]ProjectPageAddDto project)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           ProjectPage newProjectPage = this.projectPageRepo.Update(id, project);
            if(newProjectPage != null)
            return Ok(newProjectPage);
            return BadRequest();
        }
    }
}
