using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiHcc.Migrations
{
    /// <inheritdoc />
    public partial class ApiHcc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_HccAlmacen",
                columns: table => new
                {
                    alm_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    alm_cantidad = table.Column<int>(type: "int", nullable: false),
                    alm_fecha_actualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    alm_estatus = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_HccAlmacen", x => x.alm_id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_HccCatEstatusOrden",
                columns: table => new
                {
                    catord_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    catord_nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    catord_estatus = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_HccCatEstatusOrden", x => x.catord_id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_HccMesas",
                columns: table => new
                {
                    mes_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mes_lugares = table.Column<short>(type: "smallint", nullable: false),
                    mes_disponible = table.Column<byte>(type: "tinyint", nullable: false),
                    mes_estatus = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_HccMesas", x => x.mes_id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_HccOrdenes",
                columns: table => new
                {
                    ord_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mes_id = table.Column<int>(type: "int", nullable: false),
                    catord_id = table.Column<int>(type: "int", nullable: false),
                    ord_fecha_inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ord_estatus = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_HccOrdenes", x => x.ord_id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_HccProductos",
                columns: table => new
                {
                    pro_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    alm_id = table.Column<int>(type: "int", nullable: false),
                    pro_nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pro_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pro_precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    pro_estatus = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_HccProductos", x => x.pro_id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_HccOrdenesDetalle",
                columns: table => new
                {
                    orddet_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ord_id = table.Column<int>(type: "int", nullable: false),
                    pro_id = table.Column<int>(type: "int", nullable: false),
                    orddet_cantidad = table.Column<int>(type: "int", nullable: false),
                    orddet_estatus = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_HccOrdenesDetalle", x => x.orddet_id);
                    table.ForeignKey(
                        name: "FK_Tb_HccOrdenesDetalle_Tb_HccOrdenes_ord_id",
                        column: x => x.ord_id,
                        principalTable: "Tb_HccOrdenes",
                        principalColumn: "ord_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_HccOrdenesDetalle_ord_id",
                table: "Tb_HccOrdenesDetalle",
                column: "ord_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_HccAlmacen");

            migrationBuilder.DropTable(
                name: "Tb_HccCatEstatusOrden");

            migrationBuilder.DropTable(
                name: "Tb_HccMesas");

            migrationBuilder.DropTable(
                name: "Tb_HccOrdenesDetalle");

            migrationBuilder.DropTable(
                name: "Tb_HccProductos");

            migrationBuilder.DropTable(
                name: "Tb_HccOrdenes");
        }
    }
}
