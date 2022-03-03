using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lesson30_WebApi.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tblStudent",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "tblCourse",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2022, 2, 27, 21, 54, 3, 986, DateTimeKind.Local).AddTicks(5057),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 2, 27, 21, 42, 0, 473, DateTimeKind.Local).AddTicks(2729));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tblStudent");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "tblCourse",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2022, 2, 27, 21, 42, 0, 473, DateTimeKind.Local).AddTicks(2729),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 2, 27, 21, 54, 3, 986, DateTimeKind.Local).AddTicks(5057));
        }
    }
}
