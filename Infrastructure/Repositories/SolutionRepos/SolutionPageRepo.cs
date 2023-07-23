using AutoMapper;
using Data.Models.Solutoin_Page;
using Infrastructure.Construction_Context;
using Infrastructure.Dtos.DtoSolution.SolutionDto;
using Infrastructure.Dtos.DtoSolution.SolutionItemsDto;
using Infrastructure.Dtos.DtoSolution.SolutionPageDto;
using Infrastructure.Repositories.ProjectRepo.ProjectRepos;
using Infrastructure.Repositories.SolutionRepos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.SolutionRepos
{
    public class SolutionPageRepo : IPublicInterface<SolutionPageAddDto, solutionPage, SolutionPageInfoDto>
    {
        private IMapper maperr;
        private ConstructionContext constructionContext;

        public SolutionPageRepo(IMapper _mapper, ConstructionContext _constructionContext)
        {
            maperr = _mapper;
            constructionContext = _constructionContext;
        }
      
        public SolutionPageInfoDto getById(int id)
        {
            var SolutionPage = constructionContext.SolutionPage
         .Include(p => p.solution)
          .ThenInclude(p => p.solutions)
         .FirstOrDefault(p => p.Id == id);

            var solutionItemsDto = SolutionPage.solution.solutions.Select(pi => new SolutionItemsInfoDto
            {
                Id = pi.Id,
                image = pi.image,
                desc = pi.desc,
                title = pi.title,
            }).ToList();
            var solutionDto = new SolutionInfoDto
            {
                title = SolutionPage.solution.title,
                solutionItems = solutionItemsDto
            };

            var SolutionPageDto = new SolutionPageInfoDto
            {
                header = SolutionPage.header,
                bg = SolutionPage.bg,
                solutionInfoDto = solutionDto
            };

            return SolutionPageDto;
        }

        public IEnumerable<SolutionPageInfoDto> GetAll()
        {
            IEnumerable<SolutionPageInfoDto> SolutionPages = constructionContext.SolutionPage
          .Include(p => p.solution)
         .ThenInclude(p => p.solutions)
                .Select(p => new

                    SolutionPageInfoDto
                {
                    header = p.header,
                    bg = p.bg,
                    solutionInfoDto = new SolutionInfoDto
                    {
                        title = p.solution.title,
                        solutionItems = p.solution.solutions.Select(pi => new SolutionItemsInfoDto
                        {
                            Id = pi.Id,
                            image = pi.image,
                            desc = pi.desc,
                            title = pi.title,
                        }).ToList()
                    }

                }).ToList();
            return SolutionPages;
        }
        public solutionPage Insert(SolutionPageAddDto entity)
        {
            var data = maperr.Map<solutionPage>(entity);
            if (data != null)
            {
                constructionContext.Add(data);
                constructionContext.SaveChanges();
                return data;
            }
            return null;
        }

        public solutionPage Update(int id, SolutionPageAddDto entity)
        {
            solutionPage SolutionPage = constructionContext.SolutionPage.FirstOrDefault(p => p.Id == id);//getById(id);
            if (SolutionPage != null)
            {
                var data = maperr.Map(entity, SolutionPage, opt => opt.AfterMap((src,
                     dest) =>
                {
                    if (src.bg != null)
                    {
                        using var memoryStream = new MemoryStream();
                        src.bg.CopyTo(memoryStream);
                        dest.bg = memoryStream.ToArray();
                    }
                }));
                constructionContext.SaveChanges();
                return data;
            }
            return null;
        }

        public bool Delete(int id)
        {
            try
            {
                solutionPage? item = constructionContext.SolutionPage.FirstOrDefault(p => p.Id == id);
                if (item == null)
                    return false;
                else
                {
                    constructionContext.SolutionPage.Remove(item);
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
