using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Petsitters.Persistence.Migrations
{
    public partial class _1st : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Mark = table.Column<short>(type: "INTEGER", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    OwnerUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    OwnerId = table.Column<int>(type: "INTEGER", nullable: true),
                    WorkerUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    WorkerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MyServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    Details = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyServices_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    BidId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EditDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MyServiceId = table.Column<int>(type: "INTEGER", nullable: false),
                    PetId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bids_MyServices_MyServiceId",
                        column: x => x.MyServiceId,
                        principalTable: "MyServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bids_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bids_Id",
                table: "Bids",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bids_MyServiceId",
                table: "Bids",
                column: "MyServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_PetId",
                table: "Bids",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_Id",
                table: "Feedbacks",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_OwnerId",
                table: "Feedbacks",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_WorkerId",
                table: "Feedbacks",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_MyServices_Id",
                table: "MyServices",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MyServices_UserId",
                table: "MyServices",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_Id",
                table: "Pets",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_UserId",
                table: "Pets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id",
                table: "Users",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bids");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "MyServices");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
