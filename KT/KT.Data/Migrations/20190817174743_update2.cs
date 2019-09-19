using Microsoft.EntityFrameworkCore.Migrations;

namespace KT.Data.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Views",
                table: "DataViews",
                newName: "Problem");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "DataViews",
                newName: "Phone");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "DataViews",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "DataViews",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fullname",
                table: "DataViews",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "DataViews");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "DataViews");

            migrationBuilder.DropColumn(
                name: "Fullname",
                table: "DataViews");

            migrationBuilder.RenameColumn(
                name: "Problem",
                table: "DataViews",
                newName: "Views");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "DataViews",
                newName: "Name");
        }
    }
}
