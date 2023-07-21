using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Project
{
    public class ProjectPage:EntityBase
    { 
        public string header { get; set; }
        public byte[] bg { get; set; }
        //[ForeignKey("project")]
        //public int ProjectId { set; get; }
        public Project project { set; get; }
    }
}
