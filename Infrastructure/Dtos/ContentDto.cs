using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos
{
    public class ContentDto
    {
        public string header { get; set; }
        public string headerAR { get; set; }
        public IFormFile bg { set; get; }
        public string Title { set; get; }
        public string TitleAR { set; get; }
    }
}
