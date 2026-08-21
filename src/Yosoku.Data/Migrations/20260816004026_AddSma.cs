using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yosoku.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "PeRatio",
                table: "Records",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(float),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Sma200",
                table: "Records",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<float>(
                name: "Sma50",
                table: "Records",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sma200",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "Sma50",
                table: "Records");

            migrationBuilder.AlterColumn<float>(
                name: "PeRatio",
                table: "Records",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "float");
        }
    }
}
