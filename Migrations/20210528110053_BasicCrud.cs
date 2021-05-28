using Microsoft.EntityFrameworkCore.Migrations;

namespace event_API.Migrations
{
    public partial class BasicCrud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participant_Event",
                table: "Participant");

            migrationBuilder.AddForeignKey(
                name: "FK_Participant_Event",
                table: "Participant",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participant_Event",
                table: "Participant");

            migrationBuilder.AddForeignKey(
                name: "FK_Participant_Event",
                table: "Participant",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id");
        }
    }
}
