namespace DTDOrganizer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookModelUpdate : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.BooksModels");
            AlterColumn("dbo.BooksModels", "isbn", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.BooksModels", "isbn");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.BooksModels");
            AlterColumn("dbo.BooksModels", "isbn", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.BooksModels", "isbn");
        }
    }
}
