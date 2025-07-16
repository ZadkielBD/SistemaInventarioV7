using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaInventarioZ.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCarroCompraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarroCompras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioApliacionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarroCompras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarroCompras_AspNetUsers_UsuarioApliacionId",
                        column: x => x.UsuarioApliacionId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CarroCompras_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarroCompras_ProductoId",
                table: "CarroCompras",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarroCompras_UsuarioApliacionId",
                table: "CarroCompras",
                column: "UsuarioApliacionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarroCompras");
        }
    }
}
