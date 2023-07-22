using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Contact
{
    public class ContactInfo : EntityBase
    {
        public string title { get; set; }
        public string desc { get; set; }
        public string subTitle1 { set; get;  }
        public string desc1 { set; get; }
        public string subTitle2 { set; get;}
        // Address object 
        public int phone { set; get; }
        public string fax { set; get;  }
        public string email { set; get;  }
        public string web { set; get;  }
        public string image { set; get;  }

        [ForeignKey("Contact")]
        public int ContactId { set; get; }
        public Contact Contact { set; get;  }
        public ContactIcons ContactIcons { set; get; }





    }
}
