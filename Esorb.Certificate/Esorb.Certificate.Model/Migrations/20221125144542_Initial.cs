using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esorb.Certificate.Model.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CertificateData",
                columns: table => new
                {
                    CertificateDataId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SchoolYear = table.Column<short>(type: "INTEGER", nullable: false),
                    HalfYear = table.Column<short>(type: "INTEGER", nullable: false),
                    DateOfSchoolConference = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    DateOfCertificateDistribution = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    DateOfRestartLessons = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    TimeOfRestartLessons = table.Column<TimeOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificateData", x => x.CertificateDataId);
                });

            migrationBuilder.CreateTable(
                name: "SchoolClasses",
                columns: table => new
                {
                    SchoolClassId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClassName = table.Column<string>(type: "TEXT", nullable: false),
                    Yearlevel = table.Column<short>(type: "INTEGER", nullable: false),
                    HalfYear = table.Column<short>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolClasses", x => x.SchoolClassId);
                });

            migrationBuilder.CreateTable(
                name: "Pupils",
                columns: table => new
                {
                    PupilId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    YearsAtSchool = table.Column<short>(type: "INTEGER", nullable: false),
                    SchoolClassId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pupils", x => x.PupilId);
                    table.ForeignKey(
                        name: "FK_Pupils_SchoolClasses_SchoolClassId",
                        column: x => x.SchoolClassId,
                        principalTable: "SchoolClasses",
                        principalColumn: "SchoolClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pupils_SchoolClassId",
                table: "Pupils",
                column: "SchoolClassId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CertificateData");

            migrationBuilder.DropTable(
                name: "Pupils");

            migrationBuilder.DropTable(
                name: "SchoolClasses");
        }
    }
}
