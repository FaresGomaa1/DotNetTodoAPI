using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetTodoAPI.Migrations
{
    /// <inheritdoc />
    public partial class solveissuewithtaks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Todos_TodoId",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "TodoId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Todos_TodoId",
                table: "Tasks",
                column: "TodoId",
                principalTable: "Todos",
                principalColumn: "TodoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Todos_TodoId",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "TodoId",
                table: "Tasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Todos_TodoId",
                table: "Tasks",
                column: "TodoId",
                principalTable: "Todos",
                principalColumn: "TodoId");
        }
    }
}
