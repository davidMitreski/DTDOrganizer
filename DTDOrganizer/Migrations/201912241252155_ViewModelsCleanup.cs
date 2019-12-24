namespace DTDOrganizer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ViewModelsCleanup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ResourcesRequestModels", "done", c => c.Boolean(nullable: false));
            AddColumn("dbo.ResourcesRequestModels", "orderDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ResourcesRequestModels", "orderDate");
            DropColumn("dbo.ResourcesRequestModels", "done");
        }
    }
}
