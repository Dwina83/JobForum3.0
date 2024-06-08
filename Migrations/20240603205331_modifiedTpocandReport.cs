using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobForum3._0.Migrations
{
    /// <inheritdoc />
    public partial class modifiedTpocandReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Report");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Topic",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Report",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
