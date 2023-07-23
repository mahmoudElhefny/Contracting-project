using AutoMapper;
using Data.Models.Project;
using Infrastructure.Construction_Context;
using Infrastructure.Dtos.ProjectDto;
using Infrastructure.Dtos.ProjectItemsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.ProjectRepo.ProjectRepos
{
    public class ProjectItemsRepo : IPublicInterface<ProjectItemsAddDto, ProjectItems, ProjectItemsInfoDto>
    {

        private IMapper maperr;
        private ConstructionContext constructionContext;
        public ProjectItemsRepo(IMapper _mapper, ConstructionContext _constructionContext)
        {
            this.constructionContext = _constructionContext;
            this.maperr = _mapper;
        }

        public bool Delete(int id)
        {
            try
            {
                ProjectItems? item = constructionContext.ProjectItems.FirstOrDefault(p => p.Id == id);
                if (item == null)
                    return false;
                else
                {
                    constructionContext.ProjectItems.Remove(item);
                    constructionContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        
    }

        public IEnumerable<ProjectItemsInfoDto> GetAll()
        {
           List<ProjectItems> ProjectItemsDb= constructionContext.ProjectItems.ToList();
            List<ProjectItemsInfoDto> projectItemsInfoDtos = new List<ProjectItemsInfoDto>(); 
            foreach(var item in ProjectItemsDb)
            {
                ProjectItemsInfoDto projectItemsInfo = new ProjectItemsInfoDto();
                projectItemsInfo.title = item.title;
                projectItemsInfo.desc1 = item.desc1;
                projectItemsInfo.desc2 = item.desc2;
                projectItemsInfo.image = item.image;
                projectItemsInfo.Id = item.Id;
                projectItemsInfoDtos.Add(projectItemsInfo);
            }
            return projectItemsInfoDtos;
        }

        public ProjectItemsInfoDto getById(int id)
        {
            var res = this.constructionContext.ProjectItems
                 .FirstOrDefault(prop => prop.Id == id)!;
            if (res == null)
                return null;
            ProjectItemsInfoDto projectItems = new ProjectItemsInfoDto();
            projectItems.desc1 = res.desc1;
            projectItems.desc2 = res.desc2;
            projectItems.Id = res.Id;
            projectItems.image = res.image;
            projectItems.title = res.title;
            return projectItems;

        }

        
        public ProjectItems Insert(ProjectItemsAddDto entity)
        {

            var data = maperr.Map<ProjectItems>(entity);
            if (data != null)
            {
                constructionContext.Add(data);
                constructionContext.SaveChanges();
                return data;
            }
            return null;
        }

        public ProjectItems Update(int id, ProjectItemsAddDto entity)
        {

            ProjectItems projectPage = constructionContext.ProjectItems.FirstOrDefault(p => p.Id == id);//getById(id);
            if (projectPage != null)
            {
                var data = maperr.Map(entity, projectPage, opt => opt.AfterMap((src,
                     dest) =>
                {
                    if (src.image != null)
                    {
                        using var memoryStream = new MemoryStream();
                        src.image.CopyTo(memoryStream);
                        dest.image = memoryStream.ToArray();
                    }
                }));
                constructionContext.SaveChanges();
                return data;
            }
            return null;
        }
    }
}
