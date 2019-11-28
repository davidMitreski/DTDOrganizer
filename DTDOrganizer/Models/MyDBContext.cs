using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DTDOrganizer.Models
{
    public class MyDBContext : DbContext
    {

        public MyDBContext(): base("name=DefaultConnection")
        {

        }
        public DbSet<ResourcesAdminModel> AdminResources { get; set; } 
        public DbSet<ResourcesRequestModel> RequestResources { get; set; }
    }
}