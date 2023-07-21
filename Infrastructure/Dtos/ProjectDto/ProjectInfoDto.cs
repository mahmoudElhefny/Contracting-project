using Infrastructure.Dtos.ProjectItemsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.ProjectDto
{
    public class ProjectInfoDto
    {
       // public int Id { get; set; }
        //public string header { get; set; }
        public string title { get; set; }
       // public int ProjectPageID { get; set; }
        public List<ProjectItemsInfoDto> projectItems { get; set; }

    }
}
