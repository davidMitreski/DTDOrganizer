namespace DTDOrganizer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CalendarFullDay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CalendarEventModels", "allDay", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CalendarEventModels", "allDay");
        }
    }
}
