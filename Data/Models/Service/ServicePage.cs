using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Service
{
    public class ServicePage :EntityBase
    {
        public string header { set; get;  }
        public string headerAR { set; get;  }
        public string bg { set; get;  }

        //[ForeignKey("Service")]
       // public int ServiceId { set; get; }
        public Service Service { set; get;  }
    }
}
