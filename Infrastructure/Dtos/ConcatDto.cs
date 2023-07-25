using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos
{
    public class ConcatDto
    {
        public string header { set; get;  }
        public string headerAr { set; get;  }
        public string title { set; get;  }
        public string titleAR { set; get;  }
        public string desc { set; get; }
        public IFormFile bg { set; get; }

        public IFormFile web { set; get; }
        public IFormFile Image { set; get; }
        public string descAR { set; get; }
        public string subTitle1 { set; get; }
        public string subTitle1AR { set; get; }
        public string desc1 { set; get; } 
        public string desc1AR { set; get; } 
        public string subTitle2 { set; get; }
        public string subTitle2AR { set; get; }
        public string phone { set; get; }
         public string fax { set; get; }
        public string email { set; get;  }
      
        public string IcontTitle { set; get;  }
        public string IcontTitleAR { set; get;  }
    }
}
