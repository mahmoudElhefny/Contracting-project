using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.About
{
    public class AboutPage :EntityBase
    {
        public string header { set; get; }
        public byte[] bg { set; get; } /// Image
        [ForeignKey("SectionId")]
        public int SectionId { set; get; }
        public Section Section { set; get; }

    }
}
