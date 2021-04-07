using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Albums.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    ArtistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("6bc6a40b-6565-437f-8d08-b7985222f45d"), "John", "Lenon" },
                    { new Guid("5c4bee68-77c0-4b76-9fdf-5f1750d3ab6f"), "Paul", "McCartney" },
                    { new Guid("214419f4-f64f-4af8-9de1-33a31faee1c5"), "George", "Harrison" },
                    { new Guid("65cc0121-71e7-43c2-a934-974d2315c8f6"), "Ringo", "Starr" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "ArtistId", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("a091bc10-43fd-423e-9838-3b62bd22d047"), new Guid("6bc6a40b-6565-437f-8d08-b7985222f45d"), "Mind Games is the fourth studio album by English  musician John Lennon. \r\n                                    It was recorded at Record Plant Studios in New York in summer 1973. \r\n                                    The album was released in the US on 29 October 1973 and in the UK on 16 November 1973. \r\n                                    It was Lennon's first self-produced recording without help from Phil Spector.", "Mind Games" },
                    { new Guid("dd331421-7d8d-493d-858b-44263ea0b7fa"), new Guid("6bc6a40b-6565-437f-8d08-b7985222f45d"), "Imagine is the second studio album by English musician John Lennon, released on 9 September 1971 by Apple Records", "Imagine" },
                    { new Guid("4dbc2635-ccb3-425a-9527-a4b3e7d89c17"), new Guid("5c4bee68-77c0-4b76-9fdf-5f1750d3ab6f"), "Ram is a studio album by Paul McCartney and his wife Linda McCartney, released in May 1971 by Apple Records. \r\n                                    It was recorded in New York with guitarists David Spinozza and Hugh McCracken, \r\n                                    and future Wings drummer Denny Seiwell", "Ram" },
                    { new Guid("9a2f2363-0f57-41f7-b397-c9c7712c4815"), new Guid("214419f4-f64f-4af8-9de1-33a31faee1c5"), "All Things Must Pass is the third studio album by English rock musician George Harrison. \r\n                                Released as a triple album in November 1970, it was Harrison's first solo work after the break-up of the Beatles in April that year.", "All Things Must Pass" },
                    { new Guid("d79ef7b5-ceb4-4fe8-96f5-dca2b693c356"), new Guid("65cc0121-71e7-43c2-a934-974d2315c8f6"), "Sentimental Journey is the debut album by English rock musician Ringo Starr. \r\n                                    Released in 1970 as The Beatles were breaking up, Starr was the third member of the group to issue a solo recording.", "Sentimental Journey" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistId",
                table: "Albums",
                column: "ArtistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Artists");
        }
    }
}
