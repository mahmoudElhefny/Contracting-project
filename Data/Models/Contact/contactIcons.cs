using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Contact
{
    public class ContactIcons :EntityBase
    {
        public string title { set; get; }

        public ICollection<Icon> Icons { set; get;  } = new HashSet<Icon>();

        [ForeignKey("ContactInfo")]
        public int ContactInfoId { set; get; }
        public ContactInfo ContactInfo { set; get;  }


    }
}
