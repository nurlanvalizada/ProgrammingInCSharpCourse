using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lesson30_WebApi.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "tblCourse",
                type: "datetime",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 2, 27, 21, 54, 3, 986, DateTimeKind.Local).AddTicks(5057));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "tblCourse",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2022, 2, 27, 21, 54, 3, 986, DateTimeKind.Local).AddTicks(5057),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "getdate()");
        }
    }
}
