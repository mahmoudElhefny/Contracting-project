using Data.Models.Project;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.ProjectDto
{

    public class ProjectAddDto
    {
        public string header { get; set; }
 
        public string title { get; set; }

        public int ProjectPageID { get; set; }
        
    }

}
