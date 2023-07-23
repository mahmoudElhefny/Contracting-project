using Data.Models.Content;
using Infrastructure.Construction_Context;
using Infrastructure.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
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
                    .Include(i => i.Content)
                    .ThenInclude(t => t.ContentItem)
                    //.Where(g => g.Id == g.Content.ContentPageId)
                    .OrderByDescending(s => s.Id)
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
               .Include(i => i.Content)
               .ThenInclude(i => i.ContentItem)
               .OrderByDescending(i => i.Id)
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

        public async Task<dynamic> InsertContent( ContentDto dto)
        {
            IFormFile file = dto.bg;
            string NewName = Guid.NewGuid().ToString() + file.FileName;

            FileStream fs = new FileStream(
                 Path.Combine(Directory.GetCurrentDirectory(),
                  "Content", "Images", "ContentPage", NewName)
                 , FileMode.OpenOrCreate, FileAccess.ReadWrite);
            file.CopyTo(fs);
            fs.Position = 0;

            ContentPage contentPage = new ContentPage
            {
                header = dto.header,
                headerAR = dto.headerAR,
                bg = NewName ,
                Content = new Content
                {
                    Title = dto.Title,
                    TitleAR = dto.TitleAR
                }
            };
            await constructionContext.AddAsync(contentPage);
            constructionContext.SaveChanges();
            return contentPage;
        }

        
        
    }
}
