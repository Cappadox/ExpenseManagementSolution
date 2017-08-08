namespace ExpenseManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class extendtables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VPExpenseItems", "ExpenseId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VPExpenseItems", "ExpenseId");
        }
    }
}
