using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models.About
{
    public class AboutPage :EntityBase
    {
        public string header { set; get; }
        public string bg { set; get; } /// Image
        public string headerAR { set; get;}
        //[ForeignKey("Section")]
        //public int SectionId { set; get; }
        public Section Section { set; get; }

    }
}
