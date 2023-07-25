using Data.Models.Contact;
using Infrastructure.Construction_Context;
using Infrastructure.Dtos;
using Microsoft.AspNetCore.Http;
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

        public async Task<dynamic> Insert( ConcatDto dto)
        {
            IFormFile file = dto.bg;
            string NewName = Guid.NewGuid().ToString() + file.FileName;
            FileStream fs = new FileStream(
                 Path.Combine(Directory.GetCurrentDirectory(),
                  "Content", "Images", "ContactPage", NewName)
                 , FileMode.OpenOrCreate, FileAccess.ReadWrite);
            file.CopyTo(fs);
            fs.Position = 0;

            IFormFile file2 = dto.web;
            string NewName2 = Guid.NewGuid().ToString() + file2.FileName;
            FileStream fs2 = new FileStream(
                 Path.Combine(Directory.GetCurrentDirectory(),
                  "Content", "Images", "ContactPage", NewName2)
                 , FileMode.OpenOrCreate, FileAccess.ReadWrite);
            file2.CopyTo(fs2);
            fs2.Position = 0;

            IFormFile file3 = dto.Image;
            string NewName3 = Guid.NewGuid().ToString() + file3.FileName;
            FileStream fs3 = new FileStream(
                 Path.Combine(Directory.GetCurrentDirectory(),
                  "Content", "Images", "ContactPage", NewName3)
                 , FileMode.OpenOrCreate, FileAccess.ReadWrite);
            file3.CopyTo(fs3);
            fs3.Position = 0;

            var ContactPage = new Contact
            {
                header = dto.header,
                bg = NewName,
                headerAR = dto.headerAr,
                ContactInfo = new ContactInfo
                {
                    title = dto.title,
                    desc = dto.desc,
                    desc1 = dto.desc1,
                    titleAR = dto.titleAR,
                    desc1AR = dto.desc1AR,
                    descAR = dto.descAR,
                    subTitle1 = dto.subTitle1,
                    subTitle1AR = dto.subTitle1AR,
                    subTitle2 = dto.subTitle2,
                    subTitle2AR = dto.subTitle2AR,
                    phone = dto.phone,
                    email = dto.email,
                    fax = dto.fax,
                    web = NewName2,
                    image = NewName3,
                     ContactIcons = new ContactIcons
                    {
                        title = dto.IcontTitle,
                        titleAR = dto.IcontTitleAR
                    }
                },

            };
            await constructionContext.AddAsync(ContactPage);
            constructionContext.SaveChanges();

            return ContactPage;
            
        }

        public async Task<dynamic> InsertIcon(IconDto dto)
        {
            IFormFile file = dto.icon;
            string NewName = Guid.NewGuid().ToString() + file.FileName;
            FileStream fs = new FileStream(
                 Path.Combine(Directory.GetCurrentDirectory(),
                  "Content", "Images", "Icon", NewName)
                 , FileMode.OpenOrCreate, FileAccess.ReadWrite);
            file.CopyTo(fs);
            fs.Position = 0;
            var IconItem = new Icon
            {
                title = dto.title,
                titleAR = dto.titleAR,
                url = dto.url,
                icon = NewName,
                ContactIconsId = dto.ContactIconDtoId
            };
            await constructionContext.AddAsync(IconItem);
            constructionContext.SaveChanges();
            return IconItem;
        }

    }
}
