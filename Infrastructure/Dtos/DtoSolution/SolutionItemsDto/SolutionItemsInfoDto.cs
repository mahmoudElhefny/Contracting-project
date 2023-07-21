using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.DtoSolution.SolutionItemsDto
{
    public class SolutionItemsInfoDto
    {
        public int Id { get; set; }
        public byte[] image { get; set; }
        public string desc { get; set; }
        public string title { get; set; }
    }
}
