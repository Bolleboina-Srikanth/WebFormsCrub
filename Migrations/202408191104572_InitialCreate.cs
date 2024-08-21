namespace EmployeeCrubWebForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmId = c.Int(nullable: false, identity: true),
                        EName = c.String(nullable: false),
                        Salary = c.String(),
                        Department = c.String(),
                    })
                .PrimaryKey(t => t.EmId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
