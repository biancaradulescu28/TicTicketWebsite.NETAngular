using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicTicket.Migrations
{
    /// <inheritdoc />
    public partial class _17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketsId",
                table: "TicketsUsers");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "TicketsUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketsId",
                table: "TicketsUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "TicketsUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
