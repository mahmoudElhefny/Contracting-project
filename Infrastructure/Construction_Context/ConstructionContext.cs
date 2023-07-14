using Data.Models.About;
using Data.Models.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Construction_Context
{
    public class ConstructionContext : DbContext
    {

        public DbSet<AboutPage> AboutPage { set; get; }
        public DbSet<Section> Section { set; get; }
        public DbSet<Service> Services { set; get;  }
        public DbSet<ServicePage> ServicePage {  set; get; }    
        public DbSet<ServiceItem> ServiceItems { set; get; }

        public ConstructionContext(DbContextOptions<ConstructionContext> options) :base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AboutPage>().HasOne(o=>o.Section).WithOne(w=>w.Aboutpage).HasForeignKey<AboutPage>(f=>f.SectionId);
            modelBuilder.Entity<ServicePage>().HasOne(s => s.Service).WithOne(s => s.ServicePage).HasForeignKey<ServicePage>(s => s.ServiceId);
            modelBuilder.Entity<ServiceItem>().HasOne(i => i.Service).WithMany(m => m.serviceItems).HasForeignKey(f => f.ServiceId);
        }
    }
}
