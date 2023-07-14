using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Service
{
    [Table("Services")]
    public class Service :EntityBase
    {
        public string title { set; get; }
        public ServicePage ServicePage {  get; set; }
        public ICollection<ServiceItem> serviceItems { set; get; }

    }
}
