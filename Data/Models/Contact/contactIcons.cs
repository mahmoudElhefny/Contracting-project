using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models.Contact
{
    public class ContactIcons :EntityBase
    {
        public string title { set; get; }
        public string titleAR { set; get;  }
        public ICollection<Icon> Icons { set; get;  } 

        [ForeignKey("ContactInfo")]
        public int ContactInfoId { set; get; }
        [JsonIgnore]
        public ContactInfo ContactInfo { set; get;  } 


    }
}
