using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RaunstrupAuth.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Indkøbsliste_Materialer_VarenummerNavigationmaterialeID",
                table: "Indkøbsliste");

            migrationBuilder.DropIndex(
                name: "IX_Kunde_Aid",
                table: "Kunde");

            migrationBuilder.DropIndex(
                name: "IX_Indkøbsliste_VarenummerNavigationmaterialeID",
                table: "Indkøbsliste");

            migrationBuilder.DropColumn(
                name: "VarenummerNavigationmaterialeID",
                table: "Indkøbsliste");

            migrationBuilder.RenameColumn(
                name: "materialeID",
                table: "Materialer",
                newName: "Varenummer");

            migrationBuilder.AddColumn<int>(
                name: "medarbejderGruppe",
                table: "Medarbejderliste",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MedarbejderlisteMlid",
                table: "Medarbejder",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "indkøbsgruppe",
                table: "Indkøbsliste",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Navn",
                table: "Bynavn",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "materialeIndkøb",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaterialerVarenummer = table.Column<int>(nullable: true),
                    Antal = table.Column<int>(nullable: false),
                    IndkøbslisteIID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materialeIndkøb", x => x.ID);
                    table.ForeignKey(
                        name: "FK_materialeIndkøb_Indkøbsliste_IndkøbslisteIID",
                        column: x => x.IndkøbslisteIID,
                        principalTable: "Indkøbsliste",
                        principalColumn: "IID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_materialeIndkøb_Materialer_MaterialerVarenummer",
                        column: x => x.MaterialerVarenummer,
                        principalTable: "Materialer",
                        principalColumn: "Varenummer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medarbejder_MedarbejderlisteMlid",
                table: "Medarbejder",
                column: "MedarbejderlisteMlid");

            migrationBuilder.CreateIndex(
                name: "IX_Kunde_Aid",
                table: "Kunde",
                column: "Aid",
                unique: true,
                filter: "[Aid] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Indkøbsliste_Varenummer",
                table: "Indkøbsliste",
                column: "Varenummer");

            migrationBuilder.CreateIndex(
                name: "IX_materialeIndkøb_IndkøbslisteIID",
                table: "materialeIndkøb",
                column: "IndkøbslisteIID");

            migrationBuilder.CreateIndex(
                name: "IX_materialeIndkøb_MaterialerVarenummer",
                table: "materialeIndkøb",
                column: "MaterialerVarenummer");

            migrationBuilder.AddForeignKey(
                name: "FK_Indkøbsliste_Materialer_Varenummer",
                table: "Indkøbsliste",
                column: "Varenummer",
                principalTable: "Materialer",
                principalColumn: "Varenummer",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Medarbejder_Medarbejderliste_MedarbejderlisteMlid",
                table: "Medarbejder",
                column: "MedarbejderlisteMlid",
                principalTable: "Medarbejderliste",
                principalColumn: "Mlid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Indkøbsliste_Materialer_Varenummer",
                table: "Indkøbsliste");

            migrationBuilder.DropForeignKey(
                name: "FK_Medarbejder_Medarbejderliste_MedarbejderlisteMlid",
                table: "Medarbejder");

            migrationBuilder.DropTable(
                name: "materialeIndkøb");

            migrationBuilder.DropIndex(
                name: "IX_Medarbejder_MedarbejderlisteMlid",
                table: "Medarbejder");

            migrationBuilder.DropIndex(
                name: "IX_Kunde_Aid",
                table: "Kunde");

            migrationBuilder.DropIndex(
                name: "IX_Indkøbsliste_Varenummer",
                table: "Indkøbsliste");

            migrationBuilder.DropColumn(
                name: "medarbejderGruppe",
                table: "Medarbejderliste");

            migrationBuilder.DropColumn(
                name: "MedarbejderlisteMlid",
                table: "Medarbejder");

            migrationBuilder.DropColumn(
                name: "indkøbsgruppe",
                table: "Indkøbsliste");

            migrationBuilder.RenameColumn(
                name: "Varenummer",
                table: "Materialer",
                newName: "materialeID");

            migrationBuilder.AddColumn<int>(
                name: "VarenummerNavigationmaterialeID",
                table: "Indkøbsliste",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Navn",
                table: "Bynavn",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Kunde_Aid",
                table: "Kunde",
                column: "Aid");

            migrationBuilder.CreateIndex(
                name: "IX_Indkøbsliste_VarenummerNavigationmaterialeID",
                table: "Indkøbsliste",
                column: "VarenummerNavigationmaterialeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Indkøbsliste_Materialer_VarenummerNavigationmaterialeID",
                table: "Indkøbsliste",
                column: "VarenummerNavigationmaterialeID",
                principalTable: "Materialer",
                principalColumn: "materialeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
