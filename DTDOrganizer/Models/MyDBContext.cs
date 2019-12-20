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

        public System.Data.Entity.DbSet<DTDOrganizer.Models.BooksModel> BooksModels { get; set; }

        public System.Data.Entity.DbSet<DTDOrganizer.Models.CalendarEventModel> CalendarEventModels { get; set; }

        public System.Data.Entity.DbSet<DTDOrganizer.Models.CoursesModel> CoursesModels { get; set; }

        public System.Data.Entity.DbSet<DTDOrganizer.Models.DocumentsModel> DocumentsModels { get; set; }

        public System.Data.Entity.DbSet<DTDOrganizer.Models.RestaurantModel> RestaurantModels { get; set; }

        public System.Data.Entity.DbSet<DTDOrganizer.Models.OrdersModel> OrdersModels { get; set; }
    }
}