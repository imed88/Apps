using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace app.Data.Migrations
{
    public partial class UpdateSpecialite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "namePatients",
                table: "Specialites",
                newName: "nameSpecialite");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nameSpecialite",
                table: "Specialites",
                newName: "namePatients");
        }
    }
}
