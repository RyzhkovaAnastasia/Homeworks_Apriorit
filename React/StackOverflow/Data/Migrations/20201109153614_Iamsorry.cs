using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Iamsorry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnswerNumber",
                table: "Questions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerNumber",
                table: "Questions");
        }
    }
}
