using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace QLGVT.Data.EF.Migrations
{
    public partial class newKKG3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "KekhaiGiaBaseId",
                table: "KekhaiGias",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "KekhaiGiaBaseId",
                table: "KekhaiGias",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
