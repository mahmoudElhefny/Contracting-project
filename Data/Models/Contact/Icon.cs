using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Contact
{
    public class Icon :EntityBase
    {
        public string title { get; set; }
        public string titleAR { set; get;  }
        public string icon { get; set; } 
        public string url { set; get;  }
        [ForeignKey("ContactIcons")]
        public int ContactIconsId { set; get;  }
        public ContactIcons ContactIcons { get; set; }
    }
}
