namespace Sklep_MJ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetabelizamowienia : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Orders", name: "ApplicationUser_Id", newName: "UserId");
            RenameIndex(table: "dbo.Orders", name: "IX_ApplicationUser_Id", newName: "IX_UserId");
            AddColumn("dbo.Orders", "Address", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.AspNetUsers", "UserData_PostCode", c => c.String());
            AlterColumn("dbo.Orders", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Orders", "Street");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Street", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Orders", "Email", c => c.String());
            AlterColumn("dbo.Orders", "Phone", c => c.String());
            DropColumn("dbo.AspNetUsers", "UserData_PostCode");
            DropColumn("dbo.Orders", "Address");
            RenameIndex(table: "dbo.Orders", name: "IX_UserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Orders", name: "UserId", newName: "ApplicationUser_Id");
        }
    }
}
