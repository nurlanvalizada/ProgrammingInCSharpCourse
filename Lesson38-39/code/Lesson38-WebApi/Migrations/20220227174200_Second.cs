using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lesson30_WebApi.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Students_StudentTestId",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_tblCourse_CoursexId",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Genders_GendexrId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genders",
                table: "Genders");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "tblStudent");

            migrationBuilder.RenameTable(
                name: "StudentCourses",
                newName: "tblStudentCourse");

            migrationBuilder.RenameTable(
                name: "Genders",
                newName: "tblGender");

            migrationBuilder.RenameIndex(
                name: "IX_Students_GendexrId",
                table: "tblStudent",
                newName: "IX_tblStudent_GendexrId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourses_CoursexId",
                table: "tblStudentCourse",
                newName: "IX_tblStudentCourse_CoursexId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "tblCourse",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2022, 2, 27, 21, 42, 0, 473, DateTimeKind.Local).AddTicks(2729),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "tblStudent",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblStudent",
                table: "tblStudent",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblStudentCourse",
                table: "tblStudentCourse",
                columns: new[] { "StudentTestId", "CoursexId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblGender",
                table: "tblGender",
                column: "Idx");

            migrationBuilder.CreateIndex(
                name: "UIX_tblStudent_Name",
                table: "tblStudent",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Genders_GenderId",
                table: "tblStudent",
                column: "GendexrId",
                principalTable: "tblGender",
                principalColumn: "Idx",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblStudentCourse_tblCourse_CoursexId",
                table: "tblStudentCourse",
                column: "CoursexId",
                principalTable: "tblCourse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblStudentCourse_tblStudent_StudentTestId",
                table: "tblStudentCourse",
                column: "StudentTestId",
                principalTable: "tblStudent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Genders_GenderId",
                table: "tblStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_tblStudentCourse_tblCourse_CoursexId",
                table: "tblStudentCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_tblStudentCourse_tblStudent_StudentTestId",
                table: "tblStudentCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblStudentCourse",
                table: "tblStudentCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblStudent",
                table: "tblStudent");

            migrationBuilder.DropIndex(
                name: "UIX_tblStudent_Name",
                table: "tblStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblGender",
                table: "tblGender");

            migrationBuilder.RenameTable(
                name: "tblStudentCourse",
                newName: "StudentCourses");

            migrationBuilder.RenameTable(
                name: "tblStudent",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "tblGender",
                newName: "Genders");

            migrationBuilder.RenameIndex(
                name: "IX_tblStudentCourse_CoursexId",
                table: "StudentCourses",
                newName: "IX_StudentCourses_CoursexId");

            migrationBuilder.RenameIndex(
                name: "IX_tblStudent_GendexrId",
                table: "Students",
                newName: "IX_Students_GendexrId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "tblCourse",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 2, 27, 21, 42, 0, 473, DateTimeKind.Local).AddTicks(2729));

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Students",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses",
                columns: new[] { "StudentTestId", "CoursexId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genders",
                table: "Genders",
                column: "Idx");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Students_StudentTestId",
                table: "StudentCourses",
                column: "StudentTestId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_tblCourse_CoursexId",
                table: "StudentCourses",
                column: "CoursexId",
                principalTable: "tblCourse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Genders_GendexrId",
                table: "Students",
                column: "GendexrId",
                principalTable: "Genders",
                principalColumn: "Idx",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
