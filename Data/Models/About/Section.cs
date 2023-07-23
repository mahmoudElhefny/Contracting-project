using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.About
{
    public class Section :EntityBase
    {
        public string ?title { set; get;  }
        public string ?TitleAR { set; get;  }
        public string ?desc { set; get; }
        public string ?DescAR { set; get; }
        public string ?image { set; get; }  // image
        [ForeignKey("Aboutpage")]
        public int AboutPageId { set; get; }
        public AboutPage ? Aboutpage { set; get; }
    }
}
