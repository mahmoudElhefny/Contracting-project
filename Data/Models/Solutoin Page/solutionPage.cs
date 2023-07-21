
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Solutoin_Page
{
    public class solutionPage:EntityBase
    {
        public string header { get; set; }
        public byte[] bg { get; set; }
        public solution solution { set; get; }
    }
}
