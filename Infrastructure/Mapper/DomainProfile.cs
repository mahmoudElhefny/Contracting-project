using AutoMapper;
using Data.Models.Project;
using Data.Models.Solutoin_Page;
using Infrastructure.Construction_Context;
using Infrastructure.Dtos.ApplicationUsersDto;
using Infrastructure.Dtos.DtoSolution.SolutionDto;
using Infrastructure.Dtos.DtoSolution.SolutionItemsDto;
using Infrastructure.Dtos.DtoSolution.SolutionPageDto;
using Infrastructure.Dtos.ProjectDto;
using Infrastructure.Dtos.ProjectItemsDto;
using Infrastructure.Dtos.ProjectPageDto;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
           
                CreateMap<ProjectPageAddDto, ProjectPage>()
                   .ForMember(dest => dest.bg, opt => opt.MapFrom(src =>
                  MapBg(src.bg)));
                    //Project Mapper
                   CreateMap<ProjectAddDto, Project>();
            //ProjectItems Mapper
            CreateMap<ProjectItemsAddDto, ProjectItems>()
            .ForMember(dest => dest.image, opt => opt.MapFrom(src =>
           MapBg(src.image)));

            //Solution MApper
            CreateMap<SolutionPageAddDto, solutionPage>()
                  .ForMember(dest => dest.bg, opt => opt.MapFrom(src =>
                 MapBg(src.bg)));
            //Project Mapper
            CreateMap<SolutionAddDto, solution>();
            //ProjectItems Mapper
            CreateMap<SolutionItemsAddDto, solutionItems>()
            .ForMember(dest => dest.image, opt => opt.MapFrom(src =>
           MapBg(src.image)));

        }
        static byte[] MapBg(IFormFile bg)
        {
            using var memoryStream = new MemoryStream();
            bg.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }

    //    CreateMap<ApplicationUser, RegisterDto>()
    //     .ForMember(dest => dest.image, opt => opt.Ignore());
    //    CreateMap<RegisterDto, ApplicationUser>()
    //        .ForMember(dest => dest.image, opt => opt.MapFrom(src => {
    //            if (src.image != null)
    //            {
    //                using var memoryStream = new MemoryStream();
    //                src.image.CopyTo(memoryStream);
    //                return memoryStream.ToArray();
    //            }
    //            return null;
    //        }));

}
            //CreateMap<RegisterDto, ApplicationUser>()
            //.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
            //.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))       
            //.ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            //.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            //.ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            //.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));

            

        //}
    
    

