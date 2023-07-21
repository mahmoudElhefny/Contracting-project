using Infrastructure.Dtos.DtoSolution.SolutionDto;
using Infrastructure.Dtos.ProjectDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.DtoSolution.SolutionPageDto
{
    public class SolutionPageInfoDto
    {
        public int Id { get; set; }
        public string header { get; set; }
        public byte[] bg { get; set; }
        public SolutionInfoDto solutionInfoDto { get; set; }
    }
}
