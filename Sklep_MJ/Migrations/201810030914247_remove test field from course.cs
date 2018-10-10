namespace Sklep_MJ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removetestfieldfromcourse : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Courses", "Test");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Test", c => c.String());
        }
    }
}
