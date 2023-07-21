using Data.Models.Project;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Solutoin_Page
{
    public class solution:EntityBase
    {
        public string title { get; set; }
        [ForeignKey("SPage")]
        public int SolutionPageID { get; set; }
        public solutionPage SPage { get; set; }
        public ICollection<solutionItems> solutions { set; get; }
    }
}
