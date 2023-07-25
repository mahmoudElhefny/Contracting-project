using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos
{
    public class ServiceItemDto
    {
        public string title { set; get; }
        public string titleAR { set; get; }
        public string desc { set; get; }
        public string descAR { set; get; }
        public IFormFile icon { set; get; } // Image
        public int ServiceId { set; get; }
    }
}
