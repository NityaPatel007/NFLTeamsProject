using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NFLTeams.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conferences",
                columns: table => new
                {
                    ConferenceID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conferences", x => x.ConferenceID);
                });

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    DivisionID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.DivisionID);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConferenceID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DivisionID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LogoImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamID);
                    table.ForeignKey(
                        name: "FK_Teams_Conferences_ConferenceID",
                        column: x => x.ConferenceID,
                        principalTable: "Conferences",
                        principalColumn: "ConferenceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teams_Divisions_DivisionID",
                        column: x => x.DivisionID,
                        principalTable: "Divisions",
                        principalColumn: "DivisionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Conferences",
                columns: new[] { "ConferenceID", "Name" },
                values: new object[,]
                {
                    { "afc", "AFC" },
                    { "nfc", "NFC" }
                });

            migrationBuilder.InsertData(
                table: "Divisions",
                columns: new[] { "DivisionID", "Name" },
                values: new object[,]
                {
                    { "east", "East" },
                    { "north", "North" },
                    { "south", "South" },
                    { "west", "West" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamID", "ConferenceID", "DivisionID", "LogoImage", "Name" },
                values: new object[,]
                {
                    { "ari", "nfc", "west", "ARI.png", "Arizona Cardinals" },
                    { "atl", "nfc", "south", "ATL.png", "Atlanta Falcons" },
                    { "bal", "afc", "north", "BAL.png", "Baltimore Ravens" },
                    { "buf", "afc", "east", "BUF.png", "Buffalo Bills" },
                    { "car", "nfc", "south", "CAR.png", "Carolina Panthers" },
                    { "chi", "nfc", "north", "CHI.png", "Chicago Bears" },
                    { "cin", "afc", "north", "CIN.png", "Cincinnati Bengals" },
                    { "cle", "afc", "north", "CLE.png", "Cleveland Browns" },
                    { "dal", "nfc", "east", "DAL.png", "Dallas Cowboys" },
                    { "den", "afc", "west", "DEN.png", "Denver Broncos" },
                    { "det", "nfc", "north", "DET.png", "Detroit Lions" },
                    { "gb", "nfc", "north", "GB.png", "Green Bay Packers" },
                    { "hou", "afc", "south", "HOU.png", "Houston Texans" },
                    { "ind", "afc", "south", "IND.png", "Indianapolis Colts" },
                    { "jax", "afc", "south", "JAX.png", "Jacksonville Jaguars" },
                    { "kc", "afc", "west", "KC.png", "Kansas City Chiefs" },
                    { "lac", "afc", "west", "LAC.png", "Los Angeles Chargers" },
                    { "lar", "nfc", "west", "LAR.png", "Los Angeles Rams" },
                    { "lv", "afc", "west", "LV.png", "Las Vegas Raiders" },
                    { "mia", "afc", "east", "MIA.png", "Miami Dolphins" },
                    { "min", "nfc", "north", "MIN.png", "Minnesota Vikings" },
                    { "ne", "afc", "east", "NE.png", "New England Patriots" },
                    { "no", "nfc", "south", "NO.png", "New Orleans Saints" },
                    { "nyg", "nfc", "east", "NYG.png", "New York Giants" },
                    { "nyj", "afc", "east", "NYJ.png", "New York Jets" },
                    { "phi", "nfc", "east", "PHI.png", "Philadelphia Eagles" },
                    { "pit", "afc", "north", "PIT.png", "Pittsburgh Steelers" },
                    { "sea", "nfc", "west", "SEA.png", "Seattle Seahawks" },
                    { "sf", "nfc", "west", "SF.png", "San Francisco 49ers" },
                    { "tb", "nfc", "south", "TB.png", "Tampa Bay Buccaneers" },
                    { "ten", "afc", "south", "TEN.png", "Tennessee Titans" },
                    { "was", "nfc", "east", "WAS.png", "Washington Commanders" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ConferenceID",
                table: "Teams",
                column: "ConferenceID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_DivisionID",
                table: "Teams",
                column: "DivisionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Conferences");

            migrationBuilder.DropTable(
                name: "Divisions");
        }
    }
}
