using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.DataBase.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    NombreLaboratorio = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    ProveedorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoIdentificacion = table.Column<string>(nullable: true),
                    NombreRazonSocial = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    NombreContacto = table.Column<string>(nullable: true),
                    CelularContacto = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.ProveedorId);
                });

            migrationBuilder.CreateTable(
                name: "ReceptionProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHoraRecepcion = table.Column<DateTime>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false),
                    ProveedorId = table.Column<int>(nullable: false),
                    Factura = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Lote = table.Column<int>(nullable: false),
                    RegistroInvima = table.Column<string>(nullable: true),
                    FechaVencimiento = table.Column<DateTime>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceptionProducts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "ReceptionProducts");
        }
    }
}
