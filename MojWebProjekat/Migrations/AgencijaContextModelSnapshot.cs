﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace MojWebProjekat.Migrations
{
    [DbContext(typeof(AgencijaContext))]
    partial class AgencijaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Avion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UkupanBrojSedista")
                        .HasColumnType("int");

                    b.Property<string>("VremePoletanja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VremeSletanja")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Avioni");
                });

            modelBuilder.Entity("Models.Destinacija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojDana")
                        .HasColumnType("int");

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("NazivHotela")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("ID");

                    b.ToTable("Destinacije");
                });

            modelBuilder.Entity("Models.Klijent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrojTelefona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DatumPutovanja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("JmbgKlijenta")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<int?>("KlijentVakcinaID")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("KlijentVakcinaID");

                    b.ToTable("Klijenti");
                });

            modelBuilder.Entity("Models.Spoj", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AvionID")
                        .HasColumnType("int");

                    b.Property<int>("BrojSedistaKlijenta")
                        .HasColumnType("int");

                    b.Property<int?>("DestinacijaID")
                        .HasColumnType("int");

                    b.Property<int?>("KlijentID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AvionID");

                    b.HasIndex("DestinacijaID");

                    b.HasIndex("KlijentID");

                    b.ToTable("KlijentAvion");
                });

            modelBuilder.Entity("Models.Vakcina", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("DrugaDoza")
                        .HasColumnType("bit");

                    b.Property<bool>("PrvaDoza")
                        .HasColumnType("bit");

                    b.Property<bool>("Vakcinisan")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Vakcinacija");
                });

            modelBuilder.Entity("Models.Klijent", b =>
                {
                    b.HasOne("Models.Vakcina", "KlijentVakcina")
                        .WithMany("VakcinaKlijent")
                        .HasForeignKey("KlijentVakcinaID");

                    b.Navigation("KlijentVakcina");
                });

            modelBuilder.Entity("Models.Spoj", b =>
                {
                    b.HasOne("Models.Avion", "Avion")
                        .WithMany("AvionSpoj")
                        .HasForeignKey("AvionID");

                    b.HasOne("Models.Destinacija", "Destinacija")
                        .WithMany("DestinacijaSpoj")
                        .HasForeignKey("DestinacijaID");

                    b.HasOne("Models.Klijent", "Klijent")
                        .WithMany("KlijentSpoj")
                        .HasForeignKey("KlijentID");

                    b.Navigation("Avion");

                    b.Navigation("Destinacija");

                    b.Navigation("Klijent");
                });

            modelBuilder.Entity("Models.Avion", b =>
                {
                    b.Navigation("AvionSpoj");
                });

            modelBuilder.Entity("Models.Destinacija", b =>
                {
                    b.Navigation("DestinacijaSpoj");
                });

            modelBuilder.Entity("Models.Klijent", b =>
                {
                    b.Navigation("KlijentSpoj");
                });

            modelBuilder.Entity("Models.Vakcina", b =>
                {
                    b.Navigation("VakcinaKlijent");
                });
#pragma warning restore 612, 618
        }
    }
}
