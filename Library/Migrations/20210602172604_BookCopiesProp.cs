using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class BookCopiesProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Copies",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Copies",
                table: "Books");
        }
    }
}
