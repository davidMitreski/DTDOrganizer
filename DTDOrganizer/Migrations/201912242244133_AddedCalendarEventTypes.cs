namespace DTDOrganizer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCalendarEventTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CalendarEventModels", "eventType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CalendarEventModels", "eventType");
        }
    }
}
