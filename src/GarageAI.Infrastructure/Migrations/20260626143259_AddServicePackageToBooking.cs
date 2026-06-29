using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageAI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddServicePackageToBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ServicePackageId",
                table: "Bookings",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServicePackageId",
                table: "Bookings");
        }
    }
}
