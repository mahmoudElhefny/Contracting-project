using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models.Service
{
    [Table("Services")]
    public class Service :EntityBase
    {
        public string title { set; get; }
        public string titleAR { set; get; }
        [ForeignKey("ServicePage")]
        public int ServicePageId { set; get;  }
        public ServicePage ServicePage { get; set; } = new ServicePage();

        public ICollection<ServiceItem> serviceItems { set; get; } = new HashSet<ServiceItem>();

    }
}
