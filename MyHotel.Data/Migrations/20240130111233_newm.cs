using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyHotel.Data.Migrations
{
    public partial class newm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invites_Costumers_CustomerId1",
                table: "Invites");

            migrationBuilder.DropIndex(
                name: "IX_Invites_CustomerId1",
                table: "Invites");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Invites");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Invites",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Invites_CustomerId",
                table: "Invites",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invites_Costumers_CustomerId",
                table: "Invites",
                column: "CustomerId",
                principalTable: "Costumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invites_Costumers_CustomerId",
                table: "Invites");

            migrationBuilder.DropIndex(
                name: "IX_Invites_CustomerId",
                table: "Invites");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Invites",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId1",
                table: "Invites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Invites_CustomerId1",
                table: "Invites",
                column: "CustomerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Invites_Costumers_CustomerId1",
                table: "Invites",
                column: "CustomerId1",
                principalTable: "Costumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
