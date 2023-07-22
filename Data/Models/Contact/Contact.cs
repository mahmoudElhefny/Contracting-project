using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Contact
{
    public class Contact :EntityBase
    {
        public string header { get; set; }
        public string headerAR { set; get; }
        public string bg { get; set; }
        public ContactInfo ContactInfo { set; get;  } = new ContactInfo();

    }
}
