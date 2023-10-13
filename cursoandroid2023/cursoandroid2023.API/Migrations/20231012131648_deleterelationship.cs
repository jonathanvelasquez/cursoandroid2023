﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cursoandroid2023.API.Migrations
{
    /// <inheritdoc />
    public partial class deleterelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_People_PeopleId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_PeopleId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "PeopleId",
                table: "Countries");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PeopleId",
                table: "Countries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_PeopleId",
                table: "Countries",
                column: "PeopleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_People_PeopleId",
                table: "Countries",
                column: "PeopleId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
