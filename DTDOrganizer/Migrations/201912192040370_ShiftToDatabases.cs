namespace DTDOrganizer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShiftToDatabases : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BooksModels",
                c => new
                    {
                        isbn = c.Long(nullable: false),
                        title = c.String(),
                        pages = c.Int(nullable: false),
                        description = c.String(),
                        publisher = c.String(),
                        publishedDate = c.String(),
                        rating = c.Single(nullable: false),
                        imagePath = c.String(),
                    })
                .PrimaryKey(t => t.isbn);
            
            CreateTable(
                "dbo.CalendarEventModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(maxLength: 50),
                        start = c.String(),
                        end = c.String(),
                        color = c.String(),
                        description = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.CoursesModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        link = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.DocumentsModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        path = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.OrdersModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        restaurantName = c.String(),
                        order = c.String(maxLength: 150),
                        employee = c.String(),
                        orderDate = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.RestaurantModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        priceRange = c.Int(nullable: false),
                        menuImage = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RestaurantModels");
            DropTable("dbo.OrdersModels");
            DropTable("dbo.DocumentsModels");
            DropTable("dbo.CoursesModels");
            DropTable("dbo.CalendarEventModels");
            DropTable("dbo.BooksModels");
        }
    }
}
