using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPlusDemoProject.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationShipOnStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Students_StudentGradeId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_StudentGradeId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "StudentGradeId",
                table: "Grades");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Grades",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Absenteeism",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Absenteeism_StudentId",
                table: "Absenteeism",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Absenteeism_Students_StudentId",
                table: "Absenteeism",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Students_StudentId",
                table: "Grades",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absenteeism_Students_StudentId",
                table: "Absenteeism");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Students_StudentId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_StudentId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Absenteeism_StudentId",
                table: "Absenteeism");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Absenteeism");

            migrationBuilder.AddColumn<int>(
                name: "StudentGradeId",
                table: "Grades",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentGradeId",
                table: "Grades",
                column: "StudentGradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Students_StudentGradeId",
                table: "Grades",
                column: "StudentGradeId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
