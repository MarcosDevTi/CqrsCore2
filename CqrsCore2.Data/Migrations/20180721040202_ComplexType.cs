using Microsoft.EntityFrameworkCore.Migrations;

namespace CqrsCore2.Data.Migrations
{
    public partial class ComplexType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "Email_EmailAdress",
                table: "Customers",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name_FirstName",
                table: "Customers",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name_LastName",
                table: "Customers",
                maxLength: 80,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email_EmailAdress",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Name_FirstName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Name_LastName",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Customers",
                nullable: true);
        }
    }
}
