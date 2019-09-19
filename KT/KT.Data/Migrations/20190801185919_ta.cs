using Microsoft.EntityFrameworkCore.Migrations;

namespace KT.Data.Migrations
{
    public partial class ta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Datas",
                table: "Datas");

            migrationBuilder.RenameTable(
                name: "Datas",
                newName: "DataViews");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DataViews",
                table: "DataViews",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DataViews",
                table: "DataViews");

            migrationBuilder.RenameTable(
                name: "DataViews",
                newName: "Datas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Datas",
                table: "Datas",
                column: "Id");
        }
    }
}
