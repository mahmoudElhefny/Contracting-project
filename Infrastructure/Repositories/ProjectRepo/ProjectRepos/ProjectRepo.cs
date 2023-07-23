using AutoMapper;
using Data.Models.Project;
using Infrastructure.Construction_Context;
using Infrastructure.Dtos.ProjectDto;
using Infrastructure.Dtos.ProjectItemsDto;
using Infrastructure.Dtos.ProjectPageDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.ProjectRepo.ProjectRepos
{
    public class ProjectRepo : IPublicInterface<ProjectAddDto,Project,ProjectInfoDto>
    {
        
        private IMapper maperr;
        private ConstructionContext constructionContext;

        public ProjectRepo(IMapper _mapper, ConstructionContext _constructionContext)
        {
            this.maperr = _mapper;
            this.constructionContext = _constructionContext;
        }

        public IEnumerable<ProjectInfoDto> GetAll()
        {
            IEnumerable<ProjectInfoDto> projectPages = constructionContext.Project
          .Include(p => p.projects)
                .Select(p => new

                    ProjectInfoDto
                {
                   title=p.title,
       
                        projectItems = p.projects.Select(pi => new ProjectItemsInfoDto
                        {
                            Id = pi.Id,
                            image = pi.image,
                            desc1 = pi.desc1,
                            title = pi.title,
                            desc2 = pi.desc2,
                        }).ToList()
                }).ToList();
            return projectPages;
        }
        public ProjectInfoDto getById(int id)
        {
            var projectPage = constructionContext.Project
         .Include(p => p.projects)
         
         .FirstOrDefault(p => p.Id == id);

            var projectItemsDto = projectPage.projects.Select(pi => new ProjectItemsInfoDto
            {
                Id = pi.Id,
                image = pi.image,
                desc1 = pi.desc1,
                title = pi.title,
                desc2 = pi.desc2
            }).ToList();

            var projectPageDto = new ProjectInfoDto
            {
                title=projectPage.title,

            };

            return projectPageDto;
        }

        public Project Insert(ProjectAddDto entity)
        {

            var data = maperr.Map<Project>(entity);
            if (data != null)
            {
                constructionContext.Add(data);
                constructionContext.SaveChanges();
                return data;
            }
            return null;
        }

        public Project Update(int id, ProjectAddDto entity)
        {
            Project OldProject = constructionContext.Project.FirstOrDefault(p => p.Id == id);//getById(id);
            var data=maperr.Map(entity, OldProject);
            if (data != null)
            {
                constructionContext.SaveChanges();
                return data;
            }
            return null;
        }


        public bool Delete(int id)
        {
            try
            {
                Project? item = constructionContext.Project.FirstOrDefault(p => p.Id == id);
                if (item == null)
                    return false;
                else
                {
                    constructionContext.Project.Remove(item);
                    constructionContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    
    }
}
