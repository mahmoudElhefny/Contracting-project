using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Project
{
    public class ProjectItems:EntityBase
    {
        public byte[] image { get; set; }
        public string desc1 { get; set; }
        public string title { get; set; }
        public string desc2 { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { set; get; }
        public Project Project { set; get; }
    }
}
