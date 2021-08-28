using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonCatalog.Repository.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    PersonalNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false),
                    ImageFilename = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.ID);
                    table.ForeignKey(
                        name: "FK_People_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phoneNumberType = table.Column<int>(type: "int", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Relations",
                columns: table => new
                {
                    PersonToID = table.Column<int>(type: "int", nullable: false),
                    PersonFromID = table.Column<int>(type: "int", nullable: false),
                    RelationType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relations", x => new { x.PersonFromID, x.PersonToID });
                    table.ForeignKey(
                        name: "FK_Relations_People_PersonFromID",
                        column: x => x.PersonFromID,
                        principalTable: "People",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Relations_People_PersonToID",
                        column: x => x.PersonToID,
                        principalTable: "People",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "ID", "Name" },
                values: new object[] { 1, "tbilisi" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "ID", "Name" },
                values: new object[] { 2, "batumi" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "ID", "BirthDate", "CityID", "Gender", "ImageFilename", "Name", "PersonalNumber", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(1998, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, null, "rati", "00000000000", "laitadze" },
                    { 2, new DateTime(1992, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, null, "levani", "00008000001", "laitadze" },
                    { 3, new DateTime(1970, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, null, "vaxo", "00000000002", "laitadze" },
                    { 4, new DateTime(1970, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, null, "nana", "00000000003", "eliava" }
                });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "ID", "Number", "PersonID", "phoneNumberType" },
                values: new object[,]
                {
                    { 1, "000000000", 1, 1 },
                    { 2, "0320000000", 1, 3 },
                    { 3, "500000000", 2, 1 },
                    { 4, "500000001", 3, 1 },
                    { 5, "500000002", 4, 1 },
                    { 6, "50000003", 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Relations",
                columns: new[] { "PersonFromID", "PersonToID", "RelationType" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 1, 3, 1 },
                    { 2, 3, 4 },
                    { 1, 4, 4 },
                    { 2, 4, 2 },
                    { 3, 4, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_CityID",
                table: "People",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_PersonID",
                table: "PhoneNumbers",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_PersonToID",
                table: "Relations",
                column: "PersonToID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "Relations");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
