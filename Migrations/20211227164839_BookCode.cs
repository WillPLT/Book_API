using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_API.Migrations
{
    public partial class BookCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Book_code",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Book_code",
                table: "Books");
        }
    }
}
