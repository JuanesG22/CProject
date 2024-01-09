﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projectef;

#nullable disable

namespace ProjectEf.Migrations
{
    [DbContext(typeof(PacientesContext))]
    [Migration("20240109191604_InitialData")]
    partial class InitialData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("projectef.Models.Empleado", b =>
                {
                    b.Property<Guid>("EmpleadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContraseñaEmpleado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ControlPacienteporDia")
                        .HasColumnType("int");

                    b.Property<int>("DocumentoEmpleado")
                        .HasColumnType("int");

                    b.Property<string>("Especialidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechadeContratacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("TipodeContrato")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmpleadoId");

                    b.ToTable("Empleado", (string)null);

                    b.HasData(
                        new
                        {
                            EmpleadoId = new Guid("e7af78ee-36cd-4ed2-ab23-bfc80706f398"),
                            Apellido = "Ramirez Balanta",
                            ContraseñaEmpleado = "123456",
                            ControlPacienteporDia = 2,
                            DocumentoEmpleado = 1094281844,
                            Especialidad = "Medico Cirujano",
                            FechadeContratacion = new DateTime(2024, 1, 9, 14, 16, 4, 445, DateTimeKind.Local).AddTicks(3691),
                            Nombre = "Julian Andres",
                            TipodeContrato = "Termino Indefinido"
                        },
                        new
                        {
                            EmpleadoId = new Guid("265e0c8c-13d5-4a4e-a7d4-396058099e78"),
                            Apellido = "Alzate Giraldo",
                            ContraseñaEmpleado = "123457",
                            ControlPacienteporDia = 1,
                            DocumentoEmpleado = 1097839411,
                            Especialidad = "Pediatria",
                            FechadeContratacion = new DateTime(2024, 1, 9, 14, 16, 4, 445, DateTimeKind.Local).AddTicks(3707),
                            Nombre = "David",
                            TipodeContrato = "Termino Indefinido"
                        });
                });

            modelBuilder.Entity("projectef.Models.Paciente", b =>
                {
                    b.Property<Guid>("PacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescripcionCaso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DocumentoPaciente")
                        .HasColumnType("int");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<Guid>("EmpleadoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FechadeIngreso")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("PrioridadPaciente")
                        .HasColumnType("int");

                    b.HasKey("PacienteId");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("Paciente", (string)null);
                });

            modelBuilder.Entity("projectef.Models.Paciente", b =>
                {
                    b.HasOne("projectef.Models.Empleado", "Empleado")
                        .WithMany("Pacientes")
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("projectef.Models.Empleado", b =>
                {
                    b.Navigation("Pacientes");
                });
#pragma warning restore 612, 618
        }
    }
}