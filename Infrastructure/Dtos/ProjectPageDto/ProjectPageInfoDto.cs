using Infrastructure.Dtos.ProjectDto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.ProjectPageDto
{
    public class ProjectPageInfoDto
    {
        public int Id { get; set; }
        public string header { get; set; }
        public byte[] bg { get; set; }
        //public int ProjectId { get; set; }
        public ProjectInfoDto projectInfoDto { get; set; }
    }
}
