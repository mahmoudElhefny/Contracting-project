using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.DtoSolution.SolutionPageDto
{
    public class SolutionPageAddDto
    {
        public string header { get; set; }
        public IFormFile bg { get; set; }
    }
}
