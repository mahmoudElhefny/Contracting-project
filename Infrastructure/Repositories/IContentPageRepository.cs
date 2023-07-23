using Infrastructure.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IContentPageRepository
    {
        public Task<dynamic> GetAll(string Lang);
        public  Task<dynamic> InsertContent(ContentDto dto);
    }
}
