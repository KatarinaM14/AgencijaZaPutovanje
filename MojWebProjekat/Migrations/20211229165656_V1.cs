using Microsoft.EntityFrameworkCore.Migrations;

namespace MojWebProjekat.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avioni",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UkupanBrojSedista = table.Column<int>(type: "int", nullable: false),
                    VremePoletanja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VremeSletanja = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avioni", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Destinacije",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    NazivHotela = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    BrojDana = table.Column<int>(type: "int", nullable: false),
                    Cena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinacije", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vakcinacija",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vakcinisan = table.Column<bool>(type: "bit", nullable: false),
                    PrvaDoza = table.Column<bool>(type: "bit", nullable: false),
                    DrugaDoza = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vakcinacija", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Klijenti",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JmbgKlijenta = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumPutovanja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KlijentVakcinaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klijenti", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Klijenti_Vakcinacija_KlijentVakcinaID",
                        column: x => x.KlijentVakcinaID,
                        principalTable: "Vakcinacija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KlijentAvion",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojSedistaKlijenta = table.Column<int>(type: "int", nullable: false),
                    DestinacijaID = table.Column<int>(type: "int", nullable: true),
                    KlijentID = table.Column<int>(type: "int", nullable: true),
                    AvionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KlijentAvion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KlijentAvion_Avioni_AvionID",
                        column: x => x.AvionID,
                        principalTable: "Avioni",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KlijentAvion_Destinacije_DestinacijaID",
                        column: x => x.DestinacijaID,
                        principalTable: "Destinacije",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KlijentAvion_Klijenti_KlijentID",
                        column: x => x.KlijentID,
                        principalTable: "Klijenti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KlijentAvion_AvionID",
                table: "KlijentAvion",
                column: "AvionID");

            migrationBuilder.CreateIndex(
                name: "IX_KlijentAvion_DestinacijaID",
                table: "KlijentAvion",
                column: "DestinacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_KlijentAvion_KlijentID",
                table: "KlijentAvion",
                column: "KlijentID");

            migrationBuilder.CreateIndex(
                name: "IX_Klijenti_KlijentVakcinaID",
                table: "Klijenti",
                column: "KlijentVakcinaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KlijentAvion");

            migrationBuilder.DropTable(
                name: "Avioni");

            migrationBuilder.DropTable(
                name: "Destinacije");

            migrationBuilder.DropTable(
                name: "Klijenti");

            migrationBuilder.DropTable(
                name: "Vakcinacija");
        }
    }
}
