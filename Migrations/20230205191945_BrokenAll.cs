using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPlusDemoProject.Migrations
{
    /// <inheritdoc />
    public partial class BrokenAll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absenteeism_Students_StudentId",
                table: "Absenteeism");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Absenteeism",
                newName: "AbsenteeismId");

            migrationBuilder.RenameIndex(
                name: "IX_Absenteeism_StudentId",
                table: "Absenteeism",
                newName: "IX_Absenteeism_AbsenteeismId");

            migrationBuilder.AddForeignKey(
                name: "FK_Absenteeism_Absenteeism_AbsenteeismId",
                table: "Absenteeism",
                column: "AbsenteeismId",
                principalTable: "Absenteeism",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absenteeism_Absenteeism_AbsenteeismId",
                table: "Absenteeism");

            migrationBuilder.RenameColumn(
                name: "AbsenteeismId",
                table: "Absenteeism",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Absenteeism_AbsenteeismId",
                table: "Absenteeism",
                newName: "IX_Absenteeism_StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Absenteeism_Students_StudentId",
                table: "Absenteeism",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
