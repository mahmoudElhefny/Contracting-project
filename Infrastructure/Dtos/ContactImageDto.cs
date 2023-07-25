using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos
{
    public class ContactImageDto
    {

        public IFormFile bg { set; get; }

        public IFormFile web { set; get; }
        public IFormFile Image { set; get; }
    }
}
