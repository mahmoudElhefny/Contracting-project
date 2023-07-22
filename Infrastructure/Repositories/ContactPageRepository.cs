using Data.Models.Contact;
using Infrastructure.Construction_Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ContactPageRepository : IContactPageRepository
    {
        private readonly ConstructionContext constructionContext;

        public ContactPageRepository(ConstructionContext constructionContext)
        {
            this.constructionContext = constructionContext;
        }

        public async Task<dynamic> GetAll()
        {
            var result = await constructionContext.Contacts
                .OrderByDescending(i => i.Id)
                .Include(c => c.ContactInfo)
                .ThenInclude(t => t.ContactIcons).Select(r => new
                {
                    header = r.header,
                    bg = r.bg,
                    ContactInfo = new
                    {
                        title = r.ContactInfo.title,
                        desc = r.ContactInfo.desc,
                        subTitle1 = r.ContactInfo.subTitle1,
                        desc1 = r.ContactInfo.desc1,
                        subTitle2 = r.ContactInfo.subTitle2,
                        phone = r.ContactInfo.phone,
                        fax = r.ContactInfo.fax,
                        email = r.ContactInfo.email,
                        web = r.ContactInfo.web,
                        image = r.ContactInfo.image,
                      },
                ContactIcon = new
                {
                    title = r.ContactInfo.ContactIcons.title,
                    icons = r.ContactInfo.ContactIcons.Icons.Select(z => new
                    {
                        title = z.title,
                        icon = z.icon,
                        url = z.url
                    })
                }

            }).FirstOrDefaultAsync();
            return result;
        }
    }
}
