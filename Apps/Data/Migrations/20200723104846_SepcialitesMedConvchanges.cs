using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace app.Data.Migrations
{
    public partial class SepcialitesMedConvchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedConv",
                columns: table => new
                {
                    IdMedConv = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Honoraire_seance = table.Column<string>(nullable: true),
                    Jours_Usine = table.Column<string>(nullable: true),
                    MobielMedConv = table.Column<string>(nullable: true),
                    NomMedConv = table.Column<string>(nullable: true),
                    PlageHoraire = table.Column<string>(nullable: true),
                    PrenomMedConv = table.Column<string>(nullable: true),
                    idSpecialite = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedConv", x => x.IdMedConv);
                    table.ForeignKey(
                        name: "FK_MedConv_Specialites_idSpecialite",
                        column: x => x.idSpecialite,
                        principalTable: "Specialites",
                        principalColumn: "idSpecialite",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedConv_idSpecialite",
                table: "MedConv",
                column: "idSpecialite");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedConv");
        }
    }
}
