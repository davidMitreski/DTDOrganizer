namespace DTDOrganizer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixRequest : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ResourcesRequestModels");
            AlterColumn("dbo.ResourcesRequestModels", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ResourcesRequestModels", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ResourcesRequestModels");
            AlterColumn("dbo.ResourcesRequestModels", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.ResourcesRequestModels", "Id");
        }
    }
}
