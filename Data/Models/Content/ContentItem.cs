using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Content
{
    public class ContentItem :EntityBase
    {
        
        public string image { set; get; }
        public string title { set; get; }
        public string titleAR { set; get; }
        public string desc { set; get; }
        public string descAR { set; get; }

    }
}
