using Infrastructure.Dtos.DtoSolution.SolutionItemsDto;
using Infrastructure.Dtos.ProjectItemsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.DtoSolution.SolutionDto
{
    public class SolutionInfoDto
    {
        public string title { get; set; }
        // public int ProjectPageID { get; set; }
        public List<SolutionItemsInfoDto> solutionItems { get; set; }
    }
}
