using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models.Content
{
    public class ContentPage :EntityBase
    {
        
    public string header { get; set; }
    public string headerAR { get; set; }
    public string bg { set; get;  }
     [JsonIgnore]
    public Content Content { set; get;  } 
    }
}
