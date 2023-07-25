using Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos
{
    public class ServiceDto 
    {
        public string header { set; get; }
        public string headerAR { set; get; }
        public IFormFile bg { set; get; }
        public string title { set; get; }
        public string titleAR { set; get; }
    }
}
