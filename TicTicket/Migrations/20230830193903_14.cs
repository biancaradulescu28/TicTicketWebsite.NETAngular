using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicTicket.Migrations
{
    /// <inheritdoc />
    public partial class _14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketTypes_Events_EventId",
                table: "TicketTypes");

            migrationBuilder.DropIndex(
                name: "IX_TicketTypes_EventId",
                table: "TicketTypes");

            migrationBuilder.CreateTable(
                name: "EventTicketTypes",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false),
                    TicketTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTicketTypes", x => new { x.EventId, x.TicketTypesId });
                    table.ForeignKey(
                        name: "FK_EventTicketTypes_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTicketTypes_TicketTypes_TicketTypesId",
                        column: x => x.TicketTypesId,
                        principalTable: "TicketTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventTicketTypes_TicketTypesId",
                table: "EventTicketTypes",
                column: "TicketTypesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventTicketTypes");

            migrationBuilder.CreateIndex(
                name: "IX_TicketTypes_EventId",
                table: "TicketTypes",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketTypes_Events_EventId",
                table: "TicketTypes",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");
        }
    }
}
