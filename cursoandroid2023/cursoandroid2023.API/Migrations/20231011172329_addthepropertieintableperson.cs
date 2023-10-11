using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cursoandroid2023.API.Migrations
{
    /// <inheritdoc />
    public partial class addthepropertieintableperson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_People_PeopleId",
                table: "Countries");

            migrationBuilder.AlterColumn<int>(
                name: "PeopleId",
                table: "Countries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_People_PeopleId",
                table: "Countries",
                column: "PeopleId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_People_PeopleId",
                table: "Countries");

            migrationBuilder.AlterColumn<int>(
                name: "PeopleId",
                table: "Countries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_People_PeopleId",
                table: "Countries",
                column: "PeopleId",
                principalTable: "People",
                principalColumn: "Id");
        }
    }
}
