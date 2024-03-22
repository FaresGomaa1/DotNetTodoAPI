using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetTodoAPI.Migrations
{
    /// <inheritdoc />
    public partial class editdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Todos_TodoId",
                table: "Attachments");

            migrationBuilder.AlterColumn<int>(
                name: "TodoId",
                table: "Attachments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Todos_TodoId",
                table: "Attachments",
                column: "TodoId",
                principalTable: "Todos",
                principalColumn: "TodoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Todos_TodoId",
                table: "Attachments");

            migrationBuilder.AlterColumn<int>(
                name: "TodoId",
                table: "Attachments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Todos_TodoId",
                table: "Attachments",
                column: "TodoId",
                principalTable: "Todos",
                principalColumn: "TodoId");
        }
    }
}
