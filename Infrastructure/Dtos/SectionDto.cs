using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos
{
    public class SectionDto
    {
        public string? title { set; get; }
        public string? TitleAR { set; get; }
        public string? desc { set; get; }
        public string? DescAR { set; get; }
        public IFormFile? image { set; get; }  // image
        public int AboutPageId { set; get; }
    }
}
