using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Service
{
    public class ServiceItem:EntityBase
    {
        public string title { set; get; }
        public string desc { set; get; }
        public  string icon { set; get; }
        [ForeignKey("Service")]
        public int ServiceId { set; get;  }
        public Service Service { set; get; }


    }
}
