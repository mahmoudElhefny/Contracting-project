using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Content
{
    public class Content :EntityBase
    {
        public string Title { set; get;  }
        public string TitleAR { set; get;  }
        [ForeignKey("ContentPage")]
        public int ContentPageId { set; get; }
        public ContentPage ContentPage { set;get ; }
        public ICollection<ContentItem> ContentItem { set; get; }
    }
}
