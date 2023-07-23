using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Solutoin_Page
{
    public class solutionItems:EntityBase
    {
        public byte[] image { get; set; }
        public string desc { get; set; }
        public string title { get; set; }
        [ForeignKey("solution")]
        public int SolutionID { set; get; }
        public solution solution { set; get; }
    }
}
