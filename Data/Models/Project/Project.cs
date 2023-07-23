using Data.Models.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Project
{
    public class Project:EntityBase
    {
        public string title { get; set; }
        [ForeignKey("Page")]
        public int ProjectPAgeId { get; set; }
        public ProjectPage Page { get; set; }
        public ICollection<ProjectItems> projects { set; get; }
    }
}
