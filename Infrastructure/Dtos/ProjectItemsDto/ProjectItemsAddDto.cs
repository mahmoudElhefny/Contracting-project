using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.ProjectItemsDto
{
    public class ProjectItemsAddDto
    {
        public IFormFile image { get; set; }
        public string desc1 { get; set; }
        public string desc2 { get; set; }
        public string title { get; set; }
        public int projectID { get; set; }
    }
}
