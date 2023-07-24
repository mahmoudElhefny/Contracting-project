using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos
{
    public class ContentItemDto
    {
       
        public string title { set; get; }
        public string titleAR { set; get; }
        public string desc { set; get; }
        public string descAR { set; get; }
        public IFormFile image { set; get; }
        public int ContentId { set; get;  }
    }
}
