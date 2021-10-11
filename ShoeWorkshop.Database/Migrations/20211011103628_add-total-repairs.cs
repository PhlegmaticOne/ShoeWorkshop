using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoeWorkshop.Database.Migrations
{
    public partial class addtotalrepairs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalRepairs",
                schema: "ShoeWorkshop",
                table: "Workers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalRepairs",
                schema: "ShoeWorkshop",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalRepairs",
                schema: "ShoeWorkshop",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "TotalRepairs",
                schema: "ShoeWorkshop",
                table: "Customers");
        }
    }
}
