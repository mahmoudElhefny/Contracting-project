using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos
{
    public class AboutPageDto
    {

        public string ? header { set; get; }
        public IFormFile ? bg { set; get; }
        public string ? title { set; get; }
        public string ? desc { set; get; }
        public IFormFile ?image { set; get; }

    }
}
