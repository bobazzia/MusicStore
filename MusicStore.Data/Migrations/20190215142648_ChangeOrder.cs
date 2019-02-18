using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicStore.Data.Migrations
{
    public partial class ChangeOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId1",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "MusicStoreUserId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "MusicStoreUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MusicStoreUserId",
                table: "Orders",
                column: "MusicStoreUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId1",
                table: "Orders",
                column: "UserId1",
                unique: true,
                filter: "[UserId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_MusicStoreUsers_MusicStoreUserId",
                table: "Orders",
                column: "MusicStoreUserId",
                principalTable: "MusicStoreUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_MusicStoreUsers_MusicStoreUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_MusicStoreUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MusicStoreUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "MusicStoreUsers");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId1",
                table: "Orders",
                column: "UserId1");
        }
    }
}
