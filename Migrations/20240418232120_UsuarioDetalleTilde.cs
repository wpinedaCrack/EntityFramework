using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseFirst.Migrations
{
    public partial class UsuarioDetalleTilde : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Depórte",
                table: "DetalleUsuario",
                newName: "Deporte");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Deporte",
                table: "DetalleUsuario",
                newName: "Depórte");
        }
    }
}
