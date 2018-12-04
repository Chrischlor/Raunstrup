using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RaunstrupAuth.Data.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bynavn",
                columns: table => new
                {
                    ByID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Postnummer = table.Column<int>(nullable: false),
                    Navn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bynavn", x => x.ByID);
                });

            migrationBuilder.CreateTable(
                name: "Materialer",
                columns: table => new
                {
                    materialeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Navn = table.Column<string>(nullable: true),
                    Indkøbspris = table.Column<int>(nullable: true),
                    Salgspris = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materialer", x => x.materialeID);
                });

            migrationBuilder.CreateTable(
                name: "Rabat",
                columns: table => new
                {
                    Rid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rabat1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rabat", x => x.Rid);
                });

            migrationBuilder.CreateTable(
                name: "Speciale",
                columns: table => new
                {
                    Spid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SpecialeNavn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speciale", x => x.Spid);
                });

            migrationBuilder.CreateTable(
                name: "Adresse",
                columns: table => new
                {
                    AID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Byid = table.Column<int>(nullable: false),
                    Vejnavn = table.Column<string>(nullable: true),
                    Husnummer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresse", x => x.AID);
                    table.ForeignKey(
                        name: "FK_Adresse_Bynavn_Byid",
                        column: x => x.Byid,
                        principalTable: "Bynavn",
                        principalColumn: "ByID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kunde",
                columns: table => new
                {
                    Kid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Navn = table.Column<string>(nullable: true),
                    Aid = table.Column<int>(nullable: true),
                    Tlf = table.Column<int>(nullable: true),
                    Mail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunde", x => x.Kid);
                    table.ForeignKey(
                        name: "FK_Kunde_Adresse_Aid",
                        column: x => x.Aid,
                        principalTable: "Adresse",
                        principalColumn: "AID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medarbejder",
                columns: table => new
                {
                    MID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Navn = table.Column<string>(nullable: true),
                    Aid = table.Column<int>(nullable: false),
                    Tlf = table.Column<int>(nullable: false),
                    Udd = table.Column<string>(nullable: true),
                    Fudd = table.Column<bool>(nullable: false),
                    SpecialeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medarbejder", x => x.MID);
                    table.ForeignKey(
                        name: "FK_Medarbejder_Adresse_Aid",
                        column: x => x.Aid,
                        principalTable: "Adresse",
                        principalColumn: "AID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medarbejder_Speciale_SpecialeID",
                        column: x => x.SpecialeID,
                        principalTable: "Speciale",
                        principalColumn: "Spid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tilbud",
                columns: table => new
                {
                    Tid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Projekttitle = table.Column<string>(nullable: true),
                    Rid = table.Column<int>(nullable: false),
                    Kid = table.Column<int>(nullable: false),
                    Startdato = table.Column<DateTime>(nullable: false),
                    Deadline = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tilbud", x => x.Tid);
                    table.ForeignKey(
                        name: "FK_Tilbud_Kunde_Kid",
                        column: x => x.Kid,
                        principalTable: "Kunde",
                        principalColumn: "Kid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tilbud_Rabat_Rid",
                        column: x => x.Rid,
                        principalTable: "Rabat",
                        principalColumn: "Rid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Indkøbsliste",
                columns: table => new
                {
                    IID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tid = table.Column<int>(nullable: true),
                    Varenummer = table.Column<int>(nullable: true),
                    Antal = table.Column<int>(nullable: true),
                    Rid = table.Column<int>(nullable: true),
                    VarenummerNavigationmaterialeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indkøbsliste", x => x.IID);
                    table.ForeignKey(
                        name: "FK_Indkøbsliste_Rabat_Rid",
                        column: x => x.Rid,
                        principalTable: "Rabat",
                        principalColumn: "Rid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Indkøbsliste_Tilbud_Tid",
                        column: x => x.Tid,
                        principalTable: "Tilbud",
                        principalColumn: "Tid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Indkøbsliste_Materialer_VarenummerNavigationmaterialeID",
                        column: x => x.VarenummerNavigationmaterialeID,
                        principalTable: "Materialer",
                        principalColumn: "materialeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medarbejderliste",
                columns: table => new
                {
                    Mlid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tid = table.Column<int>(nullable: false),
                    Mid = table.Column<int>(nullable: false),
                    Timer = table.Column<int>(nullable: false),
                    Rid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medarbejderliste", x => x.Mlid);
                    table.ForeignKey(
                        name: "FK_Medarbejderliste_Medarbejder_Mid",
                        column: x => x.Mid,
                        principalTable: "Medarbejder",
                        principalColumn: "MID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medarbejderliste_Rabat_Rid",
                        column: x => x.Rid,
                        principalTable: "Rabat",
                        principalColumn: "Rid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medarbejderliste_Tilbud_Tid",
                        column: x => x.Tid,
                        principalTable: "Tilbud",
                        principalColumn: "Tid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projekt",
                columns: table => new
                {
                    Pid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projekt", x => x.Pid);
                    table.ForeignKey(
                        name: "FK_Projekt_Tilbud_Tid",
                        column: x => x.Tid,
                        principalTable: "Tilbud",
                        principalColumn: "Tid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresse_Byid",
                table: "Adresse",
                column: "Byid");

            migrationBuilder.CreateIndex(
                name: "IX_Indkøbsliste_Rid",
                table: "Indkøbsliste",
                column: "Rid");

            migrationBuilder.CreateIndex(
                name: "IX_Indkøbsliste_Tid",
                table: "Indkøbsliste",
                column: "Tid");

            migrationBuilder.CreateIndex(
                name: "IX_Indkøbsliste_VarenummerNavigationmaterialeID",
                table: "Indkøbsliste",
                column: "VarenummerNavigationmaterialeID");

            migrationBuilder.CreateIndex(
                name: "IX_Kunde_Aid",
                table: "Kunde",
                column: "Aid");

            migrationBuilder.CreateIndex(
                name: "IX_Medarbejder_Aid",
                table: "Medarbejder",
                column: "Aid");

            migrationBuilder.CreateIndex(
                name: "IX_Medarbejder_SpecialeID",
                table: "Medarbejder",
                column: "SpecialeID");

            migrationBuilder.CreateIndex(
                name: "IX_Medarbejderliste_Mid",
                table: "Medarbejderliste",
                column: "Mid");

            migrationBuilder.CreateIndex(
                name: "IX_Medarbejderliste_Rid",
                table: "Medarbejderliste",
                column: "Rid");

            migrationBuilder.CreateIndex(
                name: "IX_Medarbejderliste_Tid",
                table: "Medarbejderliste",
                column: "Tid");

            migrationBuilder.CreateIndex(
                name: "IX_Projekt_Tid",
                table: "Projekt",
                column: "Tid");

            migrationBuilder.CreateIndex(
                name: "IX_Tilbud_Kid",
                table: "Tilbud",
                column: "Kid");

            migrationBuilder.CreateIndex(
                name: "IX_Tilbud_Rid",
                table: "Tilbud",
                column: "Rid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Indkøbsliste");

            migrationBuilder.DropTable(
                name: "Medarbejderliste");

            migrationBuilder.DropTable(
                name: "Projekt");

            migrationBuilder.DropTable(
                name: "Materialer");

            migrationBuilder.DropTable(
                name: "Medarbejder");

            migrationBuilder.DropTable(
                name: "Tilbud");

            migrationBuilder.DropTable(
                name: "Speciale");

            migrationBuilder.DropTable(
                name: "Kunde");

            migrationBuilder.DropTable(
                name: "Rabat");

            migrationBuilder.DropTable(
                name: "Adresse");

            migrationBuilder.DropTable(
                name: "Bynavn");
        }
    }
}
