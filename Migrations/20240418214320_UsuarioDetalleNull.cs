using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseFirst.Migrations
{
    public partial class UsuarioDetalleNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuario_DetalleUsuario_DetalleUsuario_Id",
                table: "usuario");

            migrationBuilder.DropIndex(
                name: "IX_usuario_DetalleUsuario_Id",
                table: "usuario");

            migrationBuilder.AlterColumn<int>(
                name: "DetalleUsuario_Id",
                table: "usuario",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_DetalleUsuario_Id",
                table: "usuario",
                column: "DetalleUsuario_Id",
                unique: true,
                filter: "[DetalleUsuario_Id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_DetalleUsuario_DetalleUsuario_Id",
                table: "usuario",
                column: "DetalleUsuario_Id",
                principalTable: "DetalleUsuario",
                principalColumn: "DetalleUsuario_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuario_DetalleUsuario_DetalleUsuario_Id",
                table: "usuario");

            migrationBuilder.DropIndex(
                name: "IX_usuario_DetalleUsuario_Id",
                table: "usuario");

            migrationBuilder.AlterColumn<int>(
                name: "DetalleUsuario_Id",
                table: "usuario",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuario_DetalleUsuario_Id",
                table: "usuario",
                column: "DetalleUsuario_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_DetalleUsuario_DetalleUsuario_Id",
                table: "usuario",
                column: "DetalleUsuario_Id",
                principalTable: "DetalleUsuario",
                principalColumn: "DetalleUsuario_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
