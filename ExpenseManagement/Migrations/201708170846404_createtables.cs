namespace ExpenseManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createtables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VPExpenses", "StatusId", "dbo.VPExpenseHistories");
            DropForeignKey("dbo.VPExpenseItems", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.VPExpenses", new[] { "StatusId" });
            DropIndex("dbo.VPExpenseItems", new[] { "UserId" });
            AddColumn("dbo.VPExpenses", "ExpenseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.VPExpenses", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.VPExpenses", "IsDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.VPExpenseHistories", "ExpenseId", c => c.Int(nullable: false));
            AddColumn("dbo.VPExpenseItems", "ModifyDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.VPExpenseItems", "ModifyBy", c => c.String());
            AddColumn("dbo.VPExpenseItems", "ExpenseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.VPExpenses", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.VPExpenseItems", "UserId", c => c.String());
            CreateIndex("dbo.VPExpenses", "UserId");
            CreateIndex("dbo.VPExpenseHistories", "ExpenseId");
            AddForeignKey("dbo.VPExpenses", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VPExpenseHistories", "ExpenseId", "dbo.VPExpenses", "Id", cascadeDelete: true);
            DropColumn("dbo.VPExpenses", "DateOfExpense");
            DropColumn("dbo.VPExpenses", "StatusId");
            DropColumn("dbo.VPExpenseHistories", "IsPaid");
            DropColumn("dbo.VPExpenseHistories", "IsApproved");
            DropColumn("dbo.VPExpenseHistories", "DateOfApproval");
            DropColumn("dbo.VPExpenseHistories", "DateOfPayment");
            DropColumn("dbo.VPExpenseItems", "DateOfExpense");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VPExpenseItems", "DateOfExpense", c => c.DateTime(nullable: false));
            AddColumn("dbo.VPExpenseHistories", "DateOfPayment", c => c.DateTime());
            AddColumn("dbo.VPExpenseHistories", "DateOfApproval", c => c.DateTime());
            AddColumn("dbo.VPExpenseHistories", "IsApproved", c => c.Boolean(nullable: false));
            AddColumn("dbo.VPExpenseHistories", "IsPaid", c => c.Boolean(nullable: false));
            AddColumn("dbo.VPExpenses", "StatusId", c => c.Int(nullable: false));
            AddColumn("dbo.VPExpenses", "DateOfExpense", c => c.DateTime());
            DropForeignKey("dbo.VPExpenseHistories", "ExpenseId", "dbo.VPExpenses");
            DropForeignKey("dbo.VPExpenses", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.VPExpenseHistories", new[] { "ExpenseId" });
            DropIndex("dbo.VPExpenses", new[] { "UserId" });
            AlterColumn("dbo.VPExpenseItems", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.VPExpenses", "UserId", c => c.String(nullable: false));
            DropColumn("dbo.VPExpenseItems", "ExpenseDate");
            DropColumn("dbo.VPExpenseItems", "ModifyBy");
            DropColumn("dbo.VPExpenseItems", "ModifyDate");
            DropColumn("dbo.VPExpenseHistories", "ExpenseId");
            DropColumn("dbo.VPExpenses", "IsDelete");
            DropColumn("dbo.VPExpenses", "Status");
            DropColumn("dbo.VPExpenses", "ExpenseDate");
            CreateIndex("dbo.VPExpenseItems", "UserId");
            CreateIndex("dbo.VPExpenses", "StatusId");
            AddForeignKey("dbo.VPExpenseItems", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.VPExpenses", "StatusId", "dbo.VPExpenseHistories", "Id", cascadeDelete: true);
        }
    }
}
