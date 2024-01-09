using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectEf.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Edad",
                table: "Paciente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Empleado",
                columns: new[] { "EmpleadoId", "Apellido", "ContraseñaEmpleado", "ControlPacienteporDia", "DocumentoEmpleado", "Especialidad", "FechadeContratacion", "Nombre", "TipodeContrato" },
                values: new object[,]
                {
                    { new Guid("265e0c8c-13d5-4a4e-a7d4-396058099e78"), "Alzate Giraldo", "123457", 1, 1097839411, "Pediatria", new DateTime(2024, 1, 9, 14, 16, 4, 445, DateTimeKind.Local).AddTicks(3707), "David", "Termino Indefinido" },
                    { new Guid("e7af78ee-36cd-4ed2-ab23-bfc80706f398"), "Ramirez Balanta", "123456", 2, 1094281844, "Medico Cirujano", new DateTime(2024, 1, 9, 14, 16, 4, 445, DateTimeKind.Local).AddTicks(3691), "Julian Andres", "Termino Indefinido" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Empleado",
                keyColumn: "EmpleadoId",
                keyValue: new Guid("265e0c8c-13d5-4a4e-a7d4-396058099e78"));

            migrationBuilder.DeleteData(
                table: "Empleado",
                keyColumn: "EmpleadoId",
                keyValue: new Guid("e7af78ee-36cd-4ed2-ab23-bfc80706f398"));

            migrationBuilder.DropColumn(
                name: "Edad",
                table: "Paciente");
        }
    }
}
