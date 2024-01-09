using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectEf.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataPacientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "EmpleadoId",
                keyValue: new Guid("265e0c8c-13d5-4a4e-a7d4-396058099e78"),
                column: "FechadeContratacion",
                value: new DateTime(2024, 1, 9, 14, 22, 21, 853, DateTimeKind.Local).AddTicks(959));

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "EmpleadoId",
                keyValue: new Guid("e7af78ee-36cd-4ed2-ab23-bfc80706f398"),
                column: "FechadeContratacion",
                value: new DateTime(2024, 1, 9, 14, 22, 21, 853, DateTimeKind.Local).AddTicks(940));

            migrationBuilder.InsertData(
                table: "Paciente",
                columns: new[] { "PacienteId", "Apellido", "DescripcionCaso", "DocumentoPaciente", "Edad", "EmpleadoId", "FechadeIngreso", "Nombre", "PrioridadPaciente" },
                values: new object[,]
                {
                    { new Guid("e7af78ee-36cd-4ed2-ab23-bfc80706f397"), "Margareti", "Accidente laboral en donde presenta multiples heridas en la pierna causadas por un ventilador industrial", 1094829382, 35, new Guid("e7af78ee-36cd-4ed2-ab23-bfc80706f398"), new DateTime(2024, 1, 9, 14, 22, 21, 853, DateTimeKind.Local).AddTicks(1830), "Antonio", 2 },
                    { new Guid("e7af78ee-36cd-4ed2-ab23-bfc80706f399"), "Solari", "Intoxicacion por leche en polvo vencida", 1013529382, 3, new Guid("265e0c8c-13d5-4a4e-a7d4-396058099e78"), new DateTime(2024, 1, 9, 14, 22, 21, 853, DateTimeKind.Local).AddTicks(1837), "Santiago", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Paciente",
                keyColumn: "PacienteId",
                keyValue: new Guid("e7af78ee-36cd-4ed2-ab23-bfc80706f397"));

            migrationBuilder.DeleteData(
                table: "Paciente",
                keyColumn: "PacienteId",
                keyValue: new Guid("e7af78ee-36cd-4ed2-ab23-bfc80706f399"));

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "EmpleadoId",
                keyValue: new Guid("265e0c8c-13d5-4a4e-a7d4-396058099e78"),
                column: "FechadeContratacion",
                value: new DateTime(2024, 1, 9, 14, 16, 4, 445, DateTimeKind.Local).AddTicks(3707));

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "EmpleadoId",
                keyValue: new Guid("e7af78ee-36cd-4ed2-ab23-bfc80706f398"),
                column: "FechadeContratacion",
                value: new DateTime(2024, 1, 9, 14, 16, 4, 445, DateTimeKind.Local).AddTicks(3691));
        }
    }
}
