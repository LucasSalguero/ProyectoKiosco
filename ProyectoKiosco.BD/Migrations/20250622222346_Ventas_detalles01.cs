using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoKiosco.BD.Migrations
{
    /// <inheritdoc />
    public partial class Ventas_detalles01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ventas_Detalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VentaId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad_vendida = table.Column<int>(type: "int", nullable: false),
                    Precio_unitario = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas_Detalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ventas_Detalles_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ventas_Detalles_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_Detalles_ProductoId",
                table: "Ventas_Detalles",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_Detalles_VentaId",
                table: "Ventas_Detalles",
                column: "VentaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ventas_Detalles");
        }
    }
}
