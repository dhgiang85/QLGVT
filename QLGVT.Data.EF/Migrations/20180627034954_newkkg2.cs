using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace QLGVT.Data.EF.Migrations
{
    public partial class newkkg2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KekhaiGiaBaseId",
                table: "KekhaiGias",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KekhaiGiaBaseId",
                table: "KekhaiGias");
        }
    }
}
