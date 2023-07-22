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
            if (Lang == "AR")
            {
                var result = await constructionContext.ServicePage
                    .OrderByDescending(r => r.Id)
                    .Include(s => s.Service)
                    .ThenInclude(t => t.serviceItems)
                    .Select( s=> new
                        {}).FirstOrDefaultAsync();
                return result;
            }
            return null;
        }
    }
}
