namespace ExpenseManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class extendtableexpenses : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VPExpenses", "Users_Id", "dbo.AspNetUsers");
            DropIndex("dbo.VPExpenses", new[] { "Users_Id" });
            RenameColumn(table: "dbo.VPExpenses", name: "ExpenseHistory_Id", newName: "StatusId");
            RenameIndex(table: "dbo.VPExpenses", name: "IX_ExpenseHistory_Id", newName: "IX_StatusId");
            AddColumn("dbo.VPExpenses", "ModifyDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.VPExpenses", "ModifyBy", c => c.String());
            AddColumn("dbo.VPExpenses", "RejectionComment", c => c.String());
            AddColumn("dbo.VPExpenses", "Description", c => c.String());
            AlterColumn("dbo.VPExpenseHistories", "ModifyDate", c => c.DateTime());
            AlterColumn("dbo.VPExpenseHistories", "DateOfApproval", c => c.DateTime());
            AlterColumn("dbo.VPExpenseHistories", "DateOfPayment", c => c.DateTime());
            DropColumn("dbo.VPExpenses", "Users_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VPExpenses", "Users_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.VPExpenseHistories", "DateOfPayment", c => c.DateTime(nullable: false));
            AlterColumn("dbo.VPExpenseHistories", "DateOfApproval", c => c.DateTime(nullable: false));
            AlterColumn("dbo.VPExpenseHistories", "ModifyDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.VPExpenses", "Description");
            DropColumn("dbo.VPExpenses", "RejectionComment");
            DropColumn("dbo.VPExpenses", "ModifyBy");
            DropColumn("dbo.VPExpenses", "ModifyDate");
            RenameIndex(table: "dbo.VPExpenses", name: "IX_StatusId", newName: "IX_ExpenseHistory_Id");
            RenameColumn(table: "dbo.VPExpenses", name: "StatusId", newName: "ExpenseHistory_Id");
            CreateIndex("dbo.VPExpenses", "Users_Id");
            AddForeignKey("dbo.VPExpenses", "Users_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
