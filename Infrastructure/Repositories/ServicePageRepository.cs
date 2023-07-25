using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Construction_Context;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;
using Infrastructure.Dtos;
using Microsoft.AspNetCore.Http;
using Data.Models.Service;

namespace Infrastructure.Repositories
{
    
    public class ServicePageRepository : IServicePageRepository
    {
        private readonly ConstructionContext constructionContext;

        public ServicePageRepository(ConstructionContext constructionContext)
        {
            this.constructionContext = constructionContext;
        }

        public async Task<dynamic> GetAll(string Lang)
        {
            if (Lang == "EN")
            {
                var result = await constructionContext.ServicePage
                    .Include(s => s.Service)
                    .ThenInclude(t => t.serviceItems)
                    .OrderByDescending(r => r.Id)
                    .Select( s => new
                        {
                        header = s.header,
                        bg = s.bg,
                        service = new
                        {
                            title = s.Service.title,
                            services = s.Service.serviceItems.Select(z => new
                            {
                                title = z.title,
                                desc = z.desc,
                                icon = z.icon
                            })
                        }
                    }).FirstOrDefaultAsync();
                return result;
            }
            else
            {
                var result = await constructionContext.ServicePage
                   .Include(s => s.Service)
                   .ThenInclude(t => t.serviceItems)
                   .OrderByDescending(r => r.Id)
                   .Select(s => new
                   {
                       header = s.headerAR,
                       bg = s.bg,
                       service = new
                       {
                           title = s.Service.titleAR,
                           services = s.Service.serviceItems.Select(z => new
                           {
                               title = z.titleAR,
                               desc = z.descAR,
                               icon = z.icon
                           })
                       }

                   }).FirstOrDefaultAsync();
                return result;
            }
        }

        public async Task<dynamic> InsertService(ServiceDto dto)
        {
            IFormFile file = dto.bg;
            string NewName = Guid.NewGuid().ToString() + file.FileName;
            FileStream fs = new FileStream(
                 Path.Combine(Directory.GetCurrentDirectory(),
                  "Content", "Images", "ServicePage", NewName)
                 , FileMode.OpenOrCreate, FileAccess.ReadWrite);
            file.CopyTo(fs);
            fs.Position = 0;
            var servicePage = new ServicePage
            {
                header = dto.header,
                headerAR = dto.headerAR,
                bg = NewName, 

                Service = new Service
                {
                    title = dto.title,
                    titleAR = dto.titleAR,
                 
                }
            };
            await constructionContext.AddAsync(servicePage);
            constructionContext.SaveChanges();
            return servicePage;
        }

        public async Task<dynamic> InsertServiceItem(ServiceItemDto dto)
        {
            IFormFile file = dto.icon;
            string NewName = Guid.NewGuid().ToString() + file.FileName;
            FileStream fs = new FileStream(
                 Path.Combine(Directory.GetCurrentDirectory(),
                  "Content", "Images", "ServiceItem", NewName)
                 , FileMode.OpenOrCreate, FileAccess.ReadWrite);
            file.CopyTo(fs);
            fs.Position = 0;
            var serviceItem = new ServiceItem
            {
                desc = dto.desc,
                descAR = dto.descAR,
                title = dto.title,
                titleAR = dto.titleAR,
                icon = NewName,
                ServiceId = dto.ServiceId
            };
            await constructionContext.AddAsync(serviceItem);
            constructionContext.SaveChanges();
            return serviceItem;
        }
    }
}
