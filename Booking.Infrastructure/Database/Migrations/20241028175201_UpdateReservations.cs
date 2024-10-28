using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReservations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomReservation_Reservations_ReservationId",
                schema: "BO",
                table: "RoomReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomReservation_Rooms_RoomId",
                schema: "BO",
                table: "RoomReservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomReservation",
                schema: "BO",
                table: "RoomReservation");

            migrationBuilder.RenameTable(
                name: "RoomReservation",
                schema: "BO",
                newName: "RoomReservations",
                newSchema: "BO");

            migrationBuilder.RenameIndex(
                name: "IX_RoomReservation_ReservationId",
                schema: "BO",
                table: "RoomReservations",
                newName: "IX_RoomReservations_ReservationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomReservations",
                schema: "BO",
                table: "RoomReservations",
                columns: new[] { "RoomId", "ReservationId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RoomReservations_Reservations_ReservationId",
                schema: "BO",
                table: "RoomReservations",
                column: "ReservationId",
                principalSchema: "BO",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomReservations_Rooms_RoomId",
                schema: "BO",
                table: "RoomReservations",
                column: "RoomId",
                principalSchema: "BO",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomReservations_Reservations_ReservationId",
                schema: "BO",
                table: "RoomReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomReservations_Rooms_RoomId",
                schema: "BO",
                table: "RoomReservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomReservations",
                schema: "BO",
                table: "RoomReservations");

            migrationBuilder.RenameTable(
                name: "RoomReservations",
                schema: "BO",
                newName: "RoomReservation",
                newSchema: "BO");

            migrationBuilder.RenameIndex(
                name: "IX_RoomReservations_ReservationId",
                schema: "BO",
                table: "RoomReservation",
                newName: "IX_RoomReservation_ReservationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomReservation",
                schema: "BO",
                table: "RoomReservation",
                columns: new[] { "RoomId", "ReservationId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RoomReservation_Reservations_ReservationId",
                schema: "BO",
                table: "RoomReservation",
                column: "ReservationId",
                principalSchema: "BO",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomReservation_Rooms_RoomId",
                schema: "BO",
                table: "RoomReservation",
                column: "RoomId",
                principalSchema: "BO",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
