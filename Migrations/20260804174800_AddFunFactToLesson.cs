using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeQuestApp.Migrations
{
    /// <inheritdoc />
    public partial class AddFunFactToLesson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FunFact",
                table: "Lessons",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FunFact",
                table: "Lessons");
        }
    }
}
