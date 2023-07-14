using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.About
{
    public class Section :EntityBase
    {
        public string title { set; get;  }
        public string desc { set; get; }
        public string image { set; get; } 
        public AboutPage Aboutpage { set; get; }
    }
}
