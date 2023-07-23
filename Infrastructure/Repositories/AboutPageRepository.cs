using Data.Models.About;
using Infrastructure.Construction_Context;
using Infrastructure.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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
                var aboutPage =
                    await construction_Context.AboutPage
                    .Include(i => i.Section)
                    .Where(f => f.Section.AboutPageId == f.Id)
                     .OrderByDescending(o => o.Id)
                     .Select(s =>
                            new
                            {
                                header = s.headerAR,
                                bg = s.bg,
                                section = new
                                {
                                    title = s.Section.TitleAR,
                                    desc = s.Section.DescAR,
                                    image = s.Section.image
                                }
                            })
                      .FirstOrDefaultAsync();
                return aboutPage;
            }
            else
            {
                var aboutPage =
                    await construction_Context.AboutPage
                    .Include(i => i.Section)
                    .Where(f => f.Section.AboutPageId == f.Id)
                     .OrderByDescending(o => o.Id)
                     .Select(s =>
                            new
                            {
                                header = s.header,
                                bg = s.bg,
                                section = new
                                {
                                    title = s.Section.title,
                                    desc = s.Section.desc,
                                    image = s.Section.image
                                }
                            })
                      .FirstOrDefaultAsync();
                return aboutPage;

            }
        }

        public async Task<dynamic> Insert(AboutDto dto)
        {
            IFormFile file = dto.bg;
            string NewName = Guid.NewGuid().ToString() + file.FileName;

            FileStream fs = new FileStream(
                 Path.Combine(Directory.GetCurrentDirectory(),
                  "Content", "Images" ,"AboutPage" , NewName)
                 , FileMode.OpenOrCreate, FileAccess.ReadWrite);
            file.CopyTo(fs);
            fs.Position = 0;

            var aboutPage = new AboutPage
            {
                header = dto.header,
               headerAR = dto.headerAR ,
                bg = NewName
            };

          await construction_Context.AboutPage.AddAsync(aboutPage);
          construction_Context.SaveChanges();
          return aboutPage;
        }
        public async Task<dynamic> InsertSection(SectionDto SectionDto)
        {
            IFormFile file = SectionDto.image;
            string NewName = Guid.NewGuid().ToString() + file.FileName;

            FileStream fs = new FileStream(
                 Path.Combine(Directory.GetCurrentDirectory(),
                  "Content", "Images","Section" , NewName)
                 , FileMode.OpenOrCreate, FileAccess.ReadWrite);
            file.CopyTo(fs);
            fs.Position = 0;
            var Section = new Section
            {
                title = SectionDto.title,
                TitleAR = SectionDto.TitleAR ,
                DescAR = SectionDto.DescAR ,
                desc = SectionDto.desc,
                image = NewName,
                AboutPageId = SectionDto.AboutPageId       
            };
            await construction_Context.AddAsync(Section);
            construction_Context.SaveChanges();
            return Section;

        }
    }
}
