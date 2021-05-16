using Microsoft.EntityFrameworkCore.Migrations;

namespace Net5.Fundamentals.EF.CodeFirst.Migrations
{
    public partial class removefullname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                schema: "Blog",
                table: "Usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                schema: "Blog",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
