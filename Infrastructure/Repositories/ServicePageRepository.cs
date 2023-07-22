using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Construction_Context;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;

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
    }
}
