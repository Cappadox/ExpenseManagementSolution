namespace ExpenseManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeidtype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VPExpenseItems", "ExpenseId", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VPExpenseItems", "ExpenseId", c => c.String());
        }
    }
}
