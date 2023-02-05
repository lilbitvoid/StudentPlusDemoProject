using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPlusDemoProject.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Grades_GradeId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_GradeId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "Students");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "GradeId",
                table: "Students",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_GradeId",
                table: "Students",
                column: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Grades_GradeId",
                table: "Students",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id");
        }
    }
}
