namespace ExpenseManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsupervisoridtoappuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "SuperVisorId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "SuperVisorId");
        }
    }
}
