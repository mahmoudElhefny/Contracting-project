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
        public async Task<dynamic> GetAll(string Lang)
        {
            if (Lang == "EN")
            {
                var result = await constructionContext.Contact
                    //.OrderByDescending(i => i.Id)    Null Value Exception because This line  so Include of object was after orderint and this object null .
                    .Include(c => c.ContactInfo)
                    .ThenInclude(t => t.ContactIcons)
                    .ThenInclude(t => t.Icons)
                    .OrderByDescending(i => i.Id)
                    .Select(r => new
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
                        }
                    }).FirstOrDefaultAsync();
                return result;
            }
            else
            {
                var result = await constructionContext.Contact
                      .Include(c => c.ContactInfo)
                    .ThenInclude(t => t.ContactIcons)
                    .ThenInclude(t => t.Icons)
                    .OrderByDescending(i => i.Id)
                    .Select(r => new
                    {
                        header = r.headerAR,
                        bg = r.bg,
                        ContactInfo = new
                        {
                            title = r.ContactInfo.titleAR,
                            desc = r.ContactInfo.descAR,
                            subTitle1 = r.ContactInfo.subTitle1AR,
                            desc1 = r.ContactInfo.desc1AR,
                            subTitle2 = r.ContactInfo.subTitle2AR,
                            phone = r.ContactInfo.phone,
                            fax = r.ContactInfo.fax,
                            email = r.ContactInfo.email,
                            web = r.ContactInfo.web,
                            image = r.ContactInfo.image,
                            ContactIcon = new
                            {
                                title = r.ContactInfo.ContactIcons.titleAR,
                                icons = r.ContactInfo.ContactIcons.Icons.Select(z => new
                                {
                                    title = z.titleAR,
                                    icon = z.icon,
                                    url = z.url
                                })
                            }
                        }
                    }).FirstOrDefaultAsync();
                return result;
            }
        }
    }
}
