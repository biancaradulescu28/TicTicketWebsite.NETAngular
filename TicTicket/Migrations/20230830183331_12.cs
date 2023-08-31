using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicTicket.Migrations
{
    /// <inheritdoc />
    public partial class _12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketTypes_TypeId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Tickets",
                newName: "TicketTypesId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_TypeId",
                table: "Tickets",
                newName: "IX_Tickets_TicketTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketTypes_TicketTypesId",
                table: "Tickets",
                column: "TicketTypesId",
                principalTable: "TicketTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketTypes_TicketTypesId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "TicketTypesId",
                table: "Tickets",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_TicketTypesId",
                table: "Tickets",
                newName: "IX_Tickets_TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketTypes_TypeId",
                table: "Tickets",
                column: "TypeId",
                principalTable: "TicketTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
