using Microsoft.EntityFrameworkCore.Migrations;

namespace TTNtmp.Migrations
{
    public partial class SeedDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Employees (FirstName,LastName,PersonalPhone,MarketingPhone,PersonalEmail,MarketingEMail,Status) VALUES ('TestFirstName1','TestLastName1',123456789,321456789,'personaltest@test.com','marketingtest@test.com','OPT') ");
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Employees WHERE FirstName IN ('TestFirstName1')");
        }
    }
}
