using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeMaze.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { new Guid("031ceeb7-49b3-456a-b81c-02321fd3ff5b"), "John Doe's address", "John Doe" },
                    { new Guid("ecfa70cd-d028-4eb9-a8c4-31a744f2396a"), "Jane Doe's address", "Jane Doe" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Description", "OwnerId", "Type" },
                values: new object[,]
                {
                    { new Guid("8b513f04-2a77-47b1-b3eb-fdc2e090e4c1"), "Income account for our users", new Guid("ecfa70cd-d028-4eb9-a8c4-31a744f2396a"), 3 },
                    { new Guid("bdbb84ba-6989-4113-917c-68916fb2dba1"), "Cash account for our users", new Guid("031ceeb7-49b3-456a-b81c-02321fd3ff5b"), 0 },
                    { new Guid("e68ac22b-7ee9-4474-8f83-f87cb65b2cb4"), "Savings account for our users", new Guid("ecfa70cd-d028-4eb9-a8c4-31a744f2396a"), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_OwnerId",
                table: "Accounts",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
