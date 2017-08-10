namespace ExpenseManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class statusid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VPExpenses", "StatusId", "dbo.VPExpenseHistories");
            DropIndex("dbo.VPExpenses", new[] { "StatusId" });
            AlterColumn("dbo.VPExpenses", "StatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.VPExpenses", "StatusId");
            AddForeignKey("dbo.VPExpenses", "StatusId", "dbo.VPExpenseHistories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VPExpenses", "StatusId", "dbo.VPExpenseHistories");
            DropIndex("dbo.VPExpenses", new[] { "StatusId" });
            AlterColumn("dbo.VPExpenses", "StatusId", c => c.Int());
            CreateIndex("dbo.VPExpenses", "StatusId");
            AddForeignKey("dbo.VPExpenses", "StatusId", "dbo.VPExpenseHistories", "Id");
        }
    }
}
