using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yosoku.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRsi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Rsi",
                table: "Records",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rsi",
                table: "Records");
        }
    }
}
