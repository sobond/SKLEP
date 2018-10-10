namespace Sklep_MJ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addshortdescriptiontocourses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "ShortDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "ShortDescription");
        }
    }
}
