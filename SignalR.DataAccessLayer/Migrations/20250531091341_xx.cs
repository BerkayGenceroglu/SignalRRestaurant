using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccessLayer.Migrations
{
    public partial class xx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MenuTableId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MenuTables",
                columns: table => new
                {
                    MenuTableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuTables", x => x.MenuTableId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MenuTableId",
                table: "Orders",
                column: "MenuTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_MenuTables_MenuTableId",
                table: "Orders",
                column: "MenuTableId",
                principalTable: "MenuTables",
                principalColumn: "MenuTableId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_MenuTables_MenuTableId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "MenuTables");

            migrationBuilder.DropIndex(
                name: "IX_Orders_MenuTableId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MenuTableId",
                table: "Orders");
        }
    }
}
