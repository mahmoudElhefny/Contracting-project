using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.DtoSolution.SolutionItemsDto
{
    public class SolutionItemsAddDto
    {
        public IFormFile image { get; set; }
        public string desc { get; set; }
        public string title { get; set; }
        public int SolutionId { get; set; }
    }
}
