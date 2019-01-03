using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicStore.Data.Migrations
{
    public partial class tryToLogginUserAndSetFullIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "MusicStoreUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "MusicStoreUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "MusicStoreUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "MusicStoreUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "MusicStoreUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "MusicStoreUsers",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "MusicStoreUsers",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "MusicStoreUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "MusicStoreUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "MusicStoreUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "MusicStoreUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "MusicStoreUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "EmailIndex",
                table: "MusicStoreUsers");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "MusicStoreUsers");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "MusicStoreUsers");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "MusicStoreUsers");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "MusicStoreUsers");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "MusicStoreUsers");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "MusicStoreUsers");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "MusicStoreUsers");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "MusicStoreUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "MusicStoreUsers");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "MusicStoreUsers");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "MusicStoreUsers");
        }
    }
}
