using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEf.Migrations
{
    /// <inheritdoc />
    public partial class ColumnControlPacienteEmpleadosTabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ControlPacienteporDia",
                table: "Empleado",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ControlPacienteporDia",
                table: "Empleado");
        }
    }
}
