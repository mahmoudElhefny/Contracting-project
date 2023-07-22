using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models.Service
{
    public class ServiceItem:EntityBase
    {
        public string title { set; get; }
        public string titleAR { set; get; }
        public string desc { set; get; }
        public string descAR { set; get; }
        public  string icon { set; get; }
        [ForeignKey("Service")]
        [JsonIgnore]
        public int ServiceId { set; get;  }
        [JsonIgnore]
        public Service Service { set; get; }


    }
}
