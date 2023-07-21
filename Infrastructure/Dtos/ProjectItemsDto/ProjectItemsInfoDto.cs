using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.ProjectItemsDto
{
    public class ProjectItemsInfoDto
    {
        public int Id { get; set; }
        public byte[] image { get; set; }
        public string desc1 { get; set; }
        public string title { get; set; }
        public string desc2 { get; set; }
      
    }
}
