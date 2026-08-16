using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yosoku.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPeRatio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PeRatio",
                table: "Records",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeRatio",
                table: "Records");
        }
    }
}
