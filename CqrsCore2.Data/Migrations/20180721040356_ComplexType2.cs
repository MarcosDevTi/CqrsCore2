using Microsoft.EntityFrameworkCore.Migrations;

namespace CqrsCore2.Data.Migrations
{
    public partial class ComplexType2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name_LastName",
                table: "Customers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Name_FirstName",
                table: "Customers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Email_EmailAdress",
                table: "Customers",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Customers",
                newName: "Name_LastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Customers",
                newName: "Name_FirstName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Customers",
                newName: "Email_EmailAdress");
        }
    }
}
