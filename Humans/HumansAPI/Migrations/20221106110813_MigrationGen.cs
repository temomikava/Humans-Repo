using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumansAPI.Migrations
{
    public partial class MigrationGen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Humans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    PersonalNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Humans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Humans_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HumanConnection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstHumanId = table.Column<int>(type: "int", nullable: false),
                    SecondHumanId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HumanConnection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HumanConnection_Humans_FirstHumanId",
                        column: x => x.FirstHumanId,
                        principalTable: "Humans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HumanConnection_Humans_SecondHumanId",
                        column: x => x.SecondHumanId,
                        principalTable: "Humans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    HumanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phone_Humans_HumanId",
                        column: x => x.HumanId,
                        principalTable: "Humans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tbilisi" },
                    { 2, "Batumi" },
                    { 3, "Rustavi" },
                    { 4, "Zugdidi" },
                    { 5, "Qutaisi" }
                });

            migrationBuilder.InsertData(
                table: "Humans",
                columns: new[] { "Id", "CityId", "DateOfBirth", "FirstName", "Gender", "LastName", "PersonalNumber", "PhotoPath" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(1998, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Temur", (byte)0, "Mikava", "48001233222", "adlkfjakdlsf" },
                    { 2, 1, new DateTime(1997, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giorgi", (byte)0, "Giorgadze", "48001231122", "sdhfkjhdskjf" },
                    { 3, 3, new DateTime(2000, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Natia", (byte)1, "Natidze", "48341233222", "akjsdh" },
                    { 4, 5, new DateTime(2002, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Irakli", (byte)0, "Ikashvili", "48005433222", "askdjhfdjkf" },
                    { 5, 4, new DateTime(2004, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nata", (byte)1, "Natashvili", "48001267222", "asdfdfd" },
                    { 6, 1, new DateTime(1970, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tika", (byte)1, "Tikashvili", "48871233222", "asdfsdf" },
                    { 7, 2, new DateTime(2001, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lasha", (byte)0, "Lashqarava", "48001237622", "adlkfjjkhakdlsf" },
                    { 8, 3, new DateTime(1990, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tazo", (byte)0, "Tasidze", "48001393222", "asdfd" },
                    { 9, 4, new DateTime(1995, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sandro", (byte)0, "Sandroshvili", "48001233243", "adfe3" },
                    { 10, 4, new DateTime(1999, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salome", (byte)1, "Saloshvili", "48763233222", "adsfdfhdjfh" }
                });

            migrationBuilder.InsertData(
                table: "HumanConnection",
                columns: new[] { "Id", "FirstHumanId", "SecondHumanId", "Type" },
                values: new object[,]
                {
                    { 1, 2, 4, (byte)1 },
                    { 2, 1, 3, (byte)2 },
                    { 3, 3, 5, (byte)1 },
                    { 4, 8, 9, (byte)3 },
                    { 5, 7, 1, (byte)0 },
                    { 6, 4, 3, (byte)2 },
                    { 7, 9, 4, (byte)3 },
                    { 8, 2, 1, (byte)2 },
                    { 9, 7, 4, (byte)1 },
                    { 10, 8, 10, (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "Phone",
                columns: new[] { "Id", "HumanId", "PhoneNumber", "Type" },
                values: new object[,]
                {
                    { 1, 2, "344433334", (byte)1 },
                    { 2, 1, "4555555", (byte)2 },
                    { 3, 8, "6476467", (byte)1 },
                    { 4, 7, "34564356", (byte)0 },
                    { 5, 2, "345746756", (byte)0 },
                    { 6, 6, "34574656", (byte)2 },
                    { 7, 10, "23455", (byte)1 },
                    { 8, 3, "34565", (byte)0 },
                    { 9, 4, "34565", (byte)2 },
                    { 10, 5, "345432", (byte)0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HumanConnection_FirstHumanId",
                table: "HumanConnection",
                column: "FirstHumanId");

            migrationBuilder.CreateIndex(
                name: "IX_HumanConnection_SecondHumanId",
                table: "HumanConnection",
                column: "SecondHumanId");

            migrationBuilder.CreateIndex(
                name: "IX_Humans_CityId",
                table: "Humans",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_HumanId",
                table: "Phone",
                column: "HumanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HumanConnection");

            migrationBuilder.DropTable(
                name: "Phone");

            migrationBuilder.DropTable(
                name: "Humans");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
