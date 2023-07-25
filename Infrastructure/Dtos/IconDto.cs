using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos
{
    public class IconDto
    {
        public string title { get; set; }
        public string titleAR { set; get; }
        public IFormFile icon { get; set; }
        public string url { set; get; }
        public int ContactIconDtoId { set; get; }
    }
}
