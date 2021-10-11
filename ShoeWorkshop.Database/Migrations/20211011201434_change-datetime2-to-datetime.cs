using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoeWorkshop.Database.Migrations
{
    public partial class changedatetime2todatetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentTime",
                schema: "ShoeWorkshop",
                table: "Repairs",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndOfRepair",
                schema: "ShoeWorkshop",
                table: "Repairs",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentTime",
                schema: "ShoeWorkshop",
                table: "Repairs",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndOfRepair",
                schema: "ShoeWorkshop",
                table: "Repairs",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }
    }
}
