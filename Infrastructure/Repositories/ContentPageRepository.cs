using Data.Models.Content;
using Infrastructure.Construction_Context;
using Infrastructure.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ContentPageRepository : IContentPageRepository
    {
        private readonly ConstructionContext constructionContext;

        public ContentPageRepository(ConstructionContext constructionContext)
        {
            this.constructionContext = constructionContext;
        }

        public async Task<dynamic> GetAll(string Lang)
        {
            if (Lang == "AR")
            {
                var result = await constructionContext.ContentPage
                    .OrderByDescending(i => i.Id)
                    .Include(i => i.Content)
                    .ThenInclude(i => i.ContentItem)
                    .Select(s => new
                    {
                        header = s.headerAR,
                        bg = s.bg,
                        title = s.Content.TitleAR,
                        Contents = s.Content.ContentItem.Select(r => new 
                        {
                            Id = r.Id,
                            title = r.titleAR,
                            desc = r.descAR,
                            image = r.image
                        })
                    }).FirstOrDefaultAsync();
                return result;
            }
            else
            {
                var result = await constructionContext.ContentPage
               .OrderByDescending(i => i.Id)
               .Include(i => i.Content)
               .ThenInclude(i => i.ContentItem)
               .Select(s => new 
               {
                    
                   header = s.header,
                   bg = s.bg,
                   title = s.Content.Title,
                   Contents= s.Content.ContentItem.Select(r => new 
                   {
                       Id = r.Id,
                       title = r.title,
                       desc = r.desc,
                       image = r.image
                   }).ToList()
               }).FirstOrDefaultAsync();

                return result;
            }


        }
    }
}
