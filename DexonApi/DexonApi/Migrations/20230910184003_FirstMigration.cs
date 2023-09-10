using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DexonApi.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Info",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineNumber = table.Column<string>(type: "varchar(250)", nullable: true),
                    Location = table.Column<string>(type: "varchar(250)", nullable: true),
                    From = table.Column<string>(type: "varchar(250)", nullable: true),
                    To = table.Column<string>(type: "varchar(250)", nullable: true),
                    DrawingNumber = table.Column<string>(type: "varchar(250)", nullable: true),
                    Service = table.Column<string>(type: "varchar(250)", nullable: true),
                    Material = table.Column<string>(type: "varchar(250)", nullable: true),
                    InserviceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PipeSize = table.Column<double>(type: "float", nullable: false),
                    OriginalThickness = table.Column<double>(type: "float", nullable: false),
                    Stress = table.Column<double>(type: "float", nullable: false),
                    JointEfficiency = table.Column<double>(type: "float", nullable: false),
                    Ca = table.Column<double>(type: "float", nullable: false),
                    DesignLife = table.Column<double>(type: "float", nullable: false),
                    DesignPressure = table.Column<double>(type: "float", nullable: false),
                    OperatingPressure = table.Column<double>(type: "float", nullable: false),
                    DesignTemperature = table.Column<double>(type: "float", nullable: false),
                    OperatingTemperature = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Info", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cml",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InfoId = table.Column<int>(type: "int", nullable: false),
                    LineNumber = table.Column<string>(type: "varchar(250)", nullable: true),
                    CmlNumber = table.Column<int>(type: "int", nullable: false),
                    CmlDescription = table.Column<string>(type: "varchar(250)", nullable: true),
                    ActualOutsideDiameter = table.Column<double>(type: "float", nullable: false),
                    DesignThickness = table.Column<double>(type: "float", nullable: false),
                    StructuralThickness = table.Column<double>(type: "float", nullable: false),
                    RequiredThickness = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cml", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cml_Info_InfoId",
                        column: x => x.InfoId,
                        principalTable: "Info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CmlId = table.Column<int>(type: "int", nullable: false),
                    CmlNumber = table.Column<int>(type: "int", nullable: false),
                    TpNumber = table.Column<int>(type: "int", nullable: false),
                    TpDescription = table.Column<string>(type: "varchar(250)", nullable: true),
                    Note = table.Column<string>(type: "varchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestPoints_Cml_CmlId",
                        column: x => x.CmlId,
                        principalTable: "Cml",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Thicknesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TpId = table.Column<int>(type: "int", nullable: false),
                    TpNumber = table.Column<int>(type: "int", nullable: false),
                    InspectionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualThickness = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thicknesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Thicknesses_TestPoints_TpId",
                        column: x => x.TpId,
                        principalTable: "TestPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cml_InfoId",
                table: "Cml",
                column: "InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_TestPoints_CmlId",
                table: "TestPoints",
                column: "CmlId");

            migrationBuilder.CreateIndex(
                name: "IX_Thicknesses_TpId",
                table: "Thicknesses",
                column: "TpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Thicknesses");

            migrationBuilder.DropTable(
                name: "TestPoints");

            migrationBuilder.DropTable(
                name: "Cml");

            migrationBuilder.DropTable(
                name: "Info");
        }
    }
}
