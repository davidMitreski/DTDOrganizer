namespace DTDOrganizer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResourcesAdminModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(maxLength: 150),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ResourcesRequestModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        type = c.Int(nullable: false),
                        ResourceName = c.String(),
                        Qty = c.Int(nullable: false),
                        Comment = c.String(maxLength: 300),
                        Urgent = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ResourcesRequestModels");
            DropTable("dbo.ResourcesAdminModels");
        }
    }
}
