using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPlusDemoProject.Migrations
{
    /// <inheritdoc />
    public partial class BrokenAll2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absenteeism_Absenteeism_AbsenteeismId",
                table: "Absenteeism");

            migrationBuilder.DropIndex(
                name: "IX_Absenteeism_AbsenteeismId",
                table: "Absenteeism");

            migrationBuilder.DropColumn(
                name: "AbsenteeismId",
                table: "Absenteeism");

            migrationBuilder.AddColumn<int>(
                name: "AbsenteeismId",
                table: "Students",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_AbsenteeismId",
                table: "Students",
                column: "AbsenteeismId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Absenteeism_AbsenteeismId",
                table: "Students",
                column: "AbsenteeismId",
                principalTable: "Absenteeism",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Absenteeism_AbsenteeismId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_AbsenteeismId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AbsenteeismId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "AbsenteeismId",
                table: "Absenteeism",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Absenteeism_AbsenteeismId",
                table: "Absenteeism",
                column: "AbsenteeismId");

            migrationBuilder.AddForeignKey(
                name: "FK_Absenteeism_Absenteeism_AbsenteeismId",
                table: "Absenteeism",
                column: "AbsenteeismId",
                principalTable: "Absenteeism",
                principalColumn: "Id");
        }
    }
}
