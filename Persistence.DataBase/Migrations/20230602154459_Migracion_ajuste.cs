using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.DataBase.Migrations
{
    public partial class Migracion_ajuste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumIdentificacion",
                table: "Providers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumIdentificacion",
                table: "Providers");
        }
    }
}
