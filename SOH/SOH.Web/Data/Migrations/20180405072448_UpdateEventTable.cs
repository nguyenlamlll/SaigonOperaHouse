using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SOH.Web.Migrations
{
    public partial class UpdateEventTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgeInformation",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryInformation",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TicketInformation",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeInformation",
                table: "Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeInformation",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "CategoryInformation",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "TicketInformation",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "TimeInformation",
                table: "Events");
        }
    }
}
