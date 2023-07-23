using AutoMapper;
using Data.Models.Project;
using Data.Models.Solutoin_Page;
using Infrastructure.Construction_Context;
using Infrastructure.Dtos.DtoSolution.SolutionItemsDto;
using Infrastructure.Repositories.ProjectRepo.ProjectRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.SolutionRepos
{
    public class SolutionItemsRepo: IPublicInterface<SolutionItemsAddDto, solutionItems, SolutionItemsInfoDto>
    {

            private IMapper maperr;
            private ConstructionContext constructionContext;
            public SolutionItemsRepo(IMapper _mapper, ConstructionContext _constructionContext)
            {
                this.constructionContext = _constructionContext;
                this.maperr = _mapper;
            }

            public bool Delete(int id)
            {
                try
                {
                    solutionItems? item = constructionContext.solutionItems.FirstOrDefault(p => p.Id == id);
                    if (item == null)
                        return false;
                    else
                    {
                        constructionContext.solutionItems.Remove(item);
                        constructionContext.SaveChanges();
                        return true;
                    }
                }
                catch (Exception e)
                {
                    return false;
                }

            }

            public IEnumerable<SolutionItemsInfoDto> GetAll()
            {
                List<solutionItems> solutionItemsDb = constructionContext.solutionItems.ToList();
                List<SolutionItemsInfoDto> SolutionItemsInfoDtos = new List<SolutionItemsInfoDto>();
                foreach (var item in solutionItemsDb)
                {
                    SolutionItemsInfoDto solutiontemsInfo = new SolutionItemsInfoDto();
                    solutiontemsInfo.title = item.title;
                    solutiontemsInfo.desc = item.desc;
                    solutiontemsInfo.image = item.image;
                    solutiontemsInfo.Id = item.Id;
                    SolutionItemsInfoDtos.Add(solutiontemsInfo);
                }
                return SolutionItemsInfoDtos;
            }

            public SolutionItemsInfoDto getById(int id)
            {
                var res = this.constructionContext.solutionItems
                     .FirstOrDefault(prop => prop.Id == id)!;
                if (res == null)
                    return null;
                SolutionItemsInfoDto solutionitems = new SolutionItemsInfoDto();
                solutionitems.desc = res.desc;
                solutionitems.Id = res.Id;
                solutionitems.image = res.image;
                solutionitems.title = res.title;
                return solutionitems;

            }


            public solutionItems Insert(SolutionItemsAddDto entity)
            {

                var data = maperr.Map<solutionItems>(entity);
                if (data != null)
                {
                    constructionContext.Add(data);
                    constructionContext.SaveChanges();
                    return data;
                }
                return null;
            }

            public solutionItems Update(int id, SolutionItemsAddDto entity)
            {

                solutionItems projectPage = constructionContext.solutionItems.FirstOrDefault(p => p.Id == id);//getById(id);
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

