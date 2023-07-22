using Infrastructure.Construction_Context;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServiceStack.Text;

//var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var devCorsPolicy = "devCorsPolicy";
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(devCorsPolicy, builder => {
//        //builder.WithOrigins("http://localhost:800").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
//        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
//        //builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
//        //builder.SetIsOriginAllowed(origin => true);
//    });
//});


builder.Services.AddCors(options =>
{
    options.AddPolicy("Cors", builder =>
    {
        builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

//var cors = new EnableCorsAttribute("*");
//Config.Ena(cors);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<ConstructionContext>();
builder.Services.AddDbContext<ConstructionContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStr")));
builder.Services.AddScoped<IAboutPageRepository, AboutPageRepository>();
builder.Services.AddScoped<IServicePageRepository, ServicePageRepository>();
builder.Services.AddScoped<IContentPageRepository, ContentPageRepository>();
builder.Services.AddScoped<IContactPageRepository, ContactPageRepository>();
//builder.Services.AddCors();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseCors("Cors");
app.UseRouting();
//app.UseCors(devCorsPolicy);
app.UseAuthorization();

app.MapControllers();


app.Run();
