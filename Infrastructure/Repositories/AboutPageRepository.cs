using Data.Models.About;
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
    public class AboutPageRepository : IAboutPageRepository
    {
        private readonly ConstructionContext construction_Context;
        public AboutPageRepository(ConstructionContext construction_Context)
        {
            this.construction_Context = construction_Context;
        }

        public async Task<dynamic> GetAll(string Lang)
        {
            if (Lang == "AR")
            {
             var aboutPage = await construction_Context.AboutPage.Include(i => i.Section)
                   .OrderByDescending(o => o.Id)
                   .Select(s =>
                         new AboutPageDto
                         {
                             header = s.headerAR,
                             bg = s.bg,
                             title = s.Section.TitleAR,
                             desc = s.Section.DescAR,
                             image = s.Section.image
                         })
                   .FirstOrDefaultAsync();

                return aboutPage;
            }
            else
            {
              var aboutPage = await construction_Context.AboutPage.Include(i => i.Section)
                    .OrderByDescending(o => o.Id)

                .Select(s =>
                new AboutPageDto
                {
                    header = s.header,
                    bg = s.bg,
                    title = s.Section.title,
                    desc = s.Section.desc,
                    image = s.Section.image
                }).FirstOrDefaultAsync();
                return aboutPage;
            }
            
        }

        public async Task<dynamic> Insert(AboutDto dto)
        {
            using var dataStream = new MemoryStream();
            using var dataStream2 = new MemoryStream();
            dto.bg.CopyToAsync(dataStream);
            var bgTemp = dataStream.ToArray();
            dataStream.Position = 0;
            dto.image.CopyToAsync(dataStream2);
            var imageTemp = dataStream2.ToArray();
             
            AboutPage aboutPage = new AboutPage()
            {
                header = dto.header,
                bg = bgTemp ,
            Section = new Section
                {
                    title = dto.title,
                    desc = dto.desc,
                    image = imageTemp
                }
            };
            await construction_Context.AddAsync(aboutPage);
             construction_Context.SaveChangesAsync();
            return aboutPage;
            
        }

       
    }
}
