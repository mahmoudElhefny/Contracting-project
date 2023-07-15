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

        public async Task<dynamic> GetAll()
        {
            //var aboutPage = await construction_Context.AboutPage.Include(i => i.Section).Select( s =>
            //new AboutPageDto
            //{
            //    header = s.header,
            //    bg = s.bg,
            //    title = s.Section.title,
            //    desc = s.Section.desc,
            //    image = s.Section.image
            //}).ToListAsync();
            return null;
        }

        public dynamic Insert(AboutPageDto dto)
        {
            using var dataStream = new MemoryStream();

             dto.bg.CopyToAsync(dataStream);
            var bgTemp = dataStream.ToArray();
            dataStream.Position = 0;
            dto.image.CopyToAsync(dataStream);
            var imageTemp = dataStream.ToArray();
             
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
            construction_Context.Add(aboutPage);
            construction_Context.SaveChanges();
            return aboutPage;
            
        }
    }
}
