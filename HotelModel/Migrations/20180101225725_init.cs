using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HotelModel.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ActivePlayerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HbgColor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HbgColor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntrancePosition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GameLogicPersistenceId = table.Column<int>(nullable: true),
                    Position = table.Column<int>(nullable: false),
                    Side = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntrancePosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntrancePosition_Game_GameLogicPersistenceId",
                        column: x => x.GameLogicPersistenceId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CanBuyEntrance = table.Column<bool>(nullable: false),
                    ClrGridHtml = table.Column<string>(nullable: true),
                    CurrentPosition = table.Column<int>(nullable: false),
                    GameLogicPersistenceId = table.Column<int>(nullable: true),
                    Money = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PlaceholderColorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_Game_GameLogicPersistenceId",
                        column: x => x.GameLogicPersistenceId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Player_HbgColor_PlaceholderColorId",
                        column: x => x.PlaceholderColorId,
                        principalTable: "HbgColor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HotelObj",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cost = table.Column<decimal>(nullable: false),
                    CurrentCategory = table.Column<int>(nullable: false),
                    EntranceCost = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OwnerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelObj", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelObj_Player_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BuildingCost = table.Column<decimal>(nullable: false),
                    HotelObjId = table.Column<int>(nullable: true),
                    PricePerNight = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_HotelObj_HotelObjId",
                        column: x => x.HotelObjId,
                        principalTable: "HotelObj",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ownership",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GameLogicPersistenceId = table.Column<int>(nullable: true),
                    HotelId = table.Column<int>(nullable: true),
                    OwnerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ownership", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ownership_Game_GameLogicPersistenceId",
                        column: x => x.GameLogicPersistenceId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ownership_HotelObj_HotelId",
                        column: x => x.HotelId,
                        principalTable: "HotelObj",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_HotelObjId",
                table: "Category",
                column: "HotelObjId");

            migrationBuilder.CreateIndex(
                name: "IX_EntrancePosition_GameLogicPersistenceId",
                table: "EntrancePosition",
                column: "GameLogicPersistenceId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelObj_OwnerId",
                table: "HotelObj",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ownership_GameLogicPersistenceId",
                table: "Ownership",
                column: "GameLogicPersistenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Ownership_HotelId",
                table: "Ownership",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_GameLogicPersistenceId",
                table: "Player",
                column: "GameLogicPersistenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_PlaceholderColorId",
                table: "Player",
                column: "PlaceholderColorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "EntrancePosition");

            migrationBuilder.DropTable(
                name: "Ownership");

            migrationBuilder.DropTable(
                name: "HotelObj");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "HbgColor");
        }
    }
}
