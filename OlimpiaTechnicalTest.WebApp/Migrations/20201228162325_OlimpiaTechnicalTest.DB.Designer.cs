﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OlimpiaTechnicalTest.WebApp.Model;

namespace OlimpiaTechnicalTest.WebApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201228162325_OlimpiaTechnicalTest.DB")]
    partial class OlimpiaTechnicalTestDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OlimpiaTechnicalTest.WebApp.Model.Entities.Acceso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EstadioId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EstadioId");

                    b.ToTable("Accesos");
                });

            modelBuilder.Entity("OlimpiaTechnicalTest.WebApp.Model.Entities.Aficionado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NroIdentificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NroTelefonico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("TemperaturaCelsius")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Aficionados");
                });

            modelBuilder.Entity("OlimpiaTechnicalTest.WebApp.Model.Entities.Estadio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CapacidadMaxima")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OcupacionActual")
                        .HasColumnType("int");

                    b.Property<int>("PorcentajeOcupacionMaximo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Estadios");
                });

            modelBuilder.Entity("OlimpiaTechnicalTest.WebApp.Model.Entities.EstadoAficionado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AficionadoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Entrada")
                        .HasColumnType("datetime2");

                    b.Property<int>("EstadioId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Salida")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AficionadoId");

                    b.HasIndex("EstadioId");

                    b.ToTable("EstadoAficionados");
                });

            modelBuilder.Entity("OlimpiaTechnicalTest.WebApp.Model.Entities.Acceso", b =>
                {
                    b.HasOne("OlimpiaTechnicalTest.WebApp.Model.Entities.Estadio", "Estadio")
                        .WithMany("Accesos")
                        .HasForeignKey("EstadioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OlimpiaTechnicalTest.WebApp.Model.Entities.EstadoAficionado", b =>
                {
                    b.HasOne("OlimpiaTechnicalTest.WebApp.Model.Entities.Aficionado", "Aficionado")
                        .WithMany()
                        .HasForeignKey("AficionadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OlimpiaTechnicalTest.WebApp.Model.Entities.Estadio", "Estadio")
                        .WithMany()
                        .HasForeignKey("EstadioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
