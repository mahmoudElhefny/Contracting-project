using ConstructionAPIs.Controllers;
using Data.Models.Project;
using Data.Models.Solutoin_Page;
using Infrastructure.Construction_Context;
using Infrastructure.Dtos.DtoSolution.SolutionDto;
using Infrastructure.Dtos.DtoSolution.SolutionItemsDto;
using Infrastructure.Dtos.DtoSolution.SolutionPageDto;
using Infrastructure.Dtos.ProjectDto;
using Infrastructure.Dtos.ProjectItemsDto;
using Infrastructure.Dtos.ProjectPageDto;
using Infrastructure.Mapper;
using Infrastructure.Repositories;
using Infrastructure.Repositories.ApplicationUserReposatories;
using Infrastructure.Repositories.ProjectRepo.ProjectRepos;
using Infrastructure.Repositories.SolutionRepos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        //builder.Services.AddDbContext<ConstructionContext>();
        builder.Services.AddDbContext<ConstructionContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStr")));
        builder.Services.AddScoped<IAboutPageRepository, AboutPageRepository>();
        
        builder.Services.AddScoped<IPublicInterface<ProjectPageAddDto,ProjectPage,ProjectPageInfoDto>,ProjectPageRepo>();

        builder.Services.AddScoped<IPublicInterface<ProjectAddDto,Project,ProjectInfoDto> ,ProjectRepo>();
        builder.Services.AddScoped<IPublicInterface<ProjectItemsAddDto,ProjectItems,ProjectItemsInfoDto>, ProjectItemsRepo>();

        builder.Services.AddScoped<IPublicInterface<SolutionPageAddDto, solutionPage, SolutionPageInfoDto>, SolutionPageRepo> ();
        builder.Services.AddScoped<IPublicInterface<SolutionAddDto, solution, SolutionInfoDto>, SolutionRepo> ();
        builder.Services.AddScoped<IPublicInterface<SolutionItemsAddDto, solutionItems, SolutionItemsInfoDto>, SolutionItemsRepo> ();

//Inject AutoMapper
        builder.Services.AddAutoMapper(typeof(DomainProfile));
        //inject usermager
        builder.Services.AddScoped<IAppUserRepo, AppUserRepo>();
        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ConstructionContext>();
        // Add Authentication
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
          .AddJwtBearer(o =>
          {
              o.RequireHttpsMetadata = false;
              o.SaveToken = true;
              o.TokenValidationParameters = new TokenValidationParameters
              {
                  ValidateIssuerSigningKey = true,
                  ValidateIssuer = true,
                  ValidateAudience = true,
                  ValidateLifetime = true,
                  ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                  ValidAudience = builder.Configuration["JWT:ValidAudiance"],
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:secret"]))
              };
          });


                builder.Services.AddCors(corsOptions =>
                {

                    corsOptions.AddPolicy("Construction", corsPolicyBuilder =>
                    {
                        corsPolicyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    });
                });
            var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
