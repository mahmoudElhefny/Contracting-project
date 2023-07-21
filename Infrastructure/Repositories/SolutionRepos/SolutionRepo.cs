using AutoMapper;
using Data.Models.Solutoin_Page;
using Infrastructure.Construction_Context;
using Infrastructure.Dtos.DtoSolution.SolutionDto;
using Infrastructure.Dtos.DtoSolution.SolutionItemsDto;
using Infrastructure.Repositories.ProjectRepo.ProjectRepos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.SolutionRepos
{
    public class SolutionRepo: IPublicInterface<SolutionAddDto, solution, SolutionInfoDto>
    {
        private IMapper maperr;
        private ConstructionContext constructionContext;

        public SolutionRepo(IMapper _mapper, ConstructionContext _constructionContext)
        {
            this.maperr = _mapper;
            this.constructionContext = _constructionContext;
        }

        public IEnumerable<SolutionInfoDto> GetAll()
        {
            IEnumerable<SolutionInfoDto> solutionPages = constructionContext.solution
          .Include(p => p.solutions)
                .Select(p => new

                    SolutionInfoDto
                {
                    title = p.title,

                    solutionItems = p.solutions.Select(pi => new SolutionItemsInfoDto
                    {
                        Id = pi.Id,
                        image = pi.image,
                        desc = pi.desc,
                        title = pi.title,
                    }).ToList()
                }).ToList();
            return solutionPages;
        }
        public SolutionInfoDto getById(int id)
        {
            var solutionPage = constructionContext.solution
         .Include(p => p.solutions)

         .FirstOrDefault(p => p.Id == id);

            var solutionItemsDto = solutionPage.solutions.Select(pi => new SolutionItemsInfoDto
            {
                Id = pi.Id,
                image = pi.image,
                desc = pi.desc,
                title = pi.title,
            }).ToList();

            var solutionPageDto = new SolutionInfoDto
            {
                title = solutionPage.title,

            };

            return solutionPageDto;
        }

        public solution Insert(SolutionAddDto entity)
        {

            var data = maperr.Map<solution>(entity);
            if (data != null)
            {
                constructionContext.Add(data);
                constructionContext.SaveChanges();
                return data;
            }
            return null;
        }

        public solution Update(int id, SolutionAddDto entity)
        {
            solution Oldsolution = constructionContext.solution.FirstOrDefault(p => p.Id == id);//getById(id);
            var data = maperr.Map(entity, Oldsolution);
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
                solution? item = constructionContext.solution.FirstOrDefault(p => p.Id == id);
                if (item == null)
                    return false;
                else
                {
                    constructionContext.solution.Remove(item);
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
