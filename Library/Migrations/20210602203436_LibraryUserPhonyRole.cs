using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class LibraryUserPhonyRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_Patron_PatronId",
                table: "Checkouts");

            migrationBuilder.DropTable(
                name: "Patron");

            migrationBuilder.DropIndex(
                name: "IX_Checkouts_PatronId",
                table: "Checkouts");

            migrationBuilder.DropColumn(
                name: "PatronId",
                table: "Checkouts");

            migrationBuilder.AlterColumn<string>(
                name: "LibraryUserId",
                table: "Checkouts",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsLibrarian",
                table: "AspNetUsers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_LibraryUserId",
                table: "Checkouts",
                column: "LibraryUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_AspNetUsers_LibraryUserId",
                table: "Checkouts",
                column: "LibraryUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_AspNetUsers_LibraryUserId",
                table: "Checkouts");

            migrationBuilder.DropIndex(
                name: "IX_Checkouts_LibraryUserId",
                table: "Checkouts");

            migrationBuilder.DropColumn(
                name: "IsLibrarian",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "LibraryUserId",
                table: "Checkouts",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatronId",
                table: "Checkouts",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Patron",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Email = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    PasswordHash = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SecurityStamp = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patron", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_PatronId",
                table: "Checkouts",
                column: "PatronId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_Patron_PatronId",
                table: "Checkouts",
                column: "PatronId",
                principalTable: "Patron",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
