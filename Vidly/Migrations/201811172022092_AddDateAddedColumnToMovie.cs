namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateAddedColumnToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "DateAdded");
        }
    }
}
