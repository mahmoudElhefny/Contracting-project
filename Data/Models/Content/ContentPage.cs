using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Content
{
    public class ContentPage :EntityBase
    {
        
    public string header { get; set; }
    public string headerAR { get; set; }
    public string bg { set; get;  }
    
    public Content Content { set; get;  } 
    }
}
