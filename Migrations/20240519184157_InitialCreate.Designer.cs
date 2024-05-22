﻿// <auto-generated />
using System;
using ClubsGestionLastVersion.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClubsGestionLastVersion.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240519184157_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClubsGestionLastVersion.Models.Activite", b =>
                {
                    b.Property<int>("ActiviteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActiviteId"));

                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFin")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ActiviteId");

                    b.HasIndex("ClubId");

                    b.ToTable("Activites");
                });

            modelBuilder.Entity("ClubsGestionLastVersion.Models.Club", b =>
                {
                    b.Property<int>("ClubId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClubId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ClubId");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("ClubsGestionLastVersion.Models.Evenement", b =>
                {
                    b.Property<int>("EvenementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EvenementId"));

                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateEvenement")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomEvenement")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("EvenementId");

                    b.HasIndex("ClubId");

                    b.ToTable("Evenements");
                });

            modelBuilder.Entity("ClubsGestionLastVersion.Models.Membre", b =>
                {
                    b.Property<int>("MembreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MembreId"));

                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAdhesion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("MembreId");

                    b.HasIndex("ClubId");

                    b.HasIndex("RoleId");

                    b.ToTable("Membres");
                });

            modelBuilder.Entity("ClubsGestionLastVersion.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomRole")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ClubsGestionLastVersion.Models.Activite", b =>
                {
                    b.HasOne("ClubsGestionLastVersion.Models.Club", "Club")
                        .WithMany("Activites")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Club");
                });

            modelBuilder.Entity("ClubsGestionLastVersion.Models.Evenement", b =>
                {
                    b.HasOne("ClubsGestionLastVersion.Models.Club", "Club")
                        .WithMany()
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Club");
                });

            modelBuilder.Entity("ClubsGestionLastVersion.Models.Membre", b =>
                {
                    b.HasOne("ClubsGestionLastVersion.Models.Club", "Club")
                        .WithMany("Membres")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClubsGestionLastVersion.Models.Role", null)
                        .WithMany("Membres")
                        .HasForeignKey("RoleId");

                    b.Navigation("Club");
                });

            modelBuilder.Entity("ClubsGestionLastVersion.Models.Club", b =>
                {
                    b.Navigation("Activites");

                    b.Navigation("Membres");
                });

            modelBuilder.Entity("ClubsGestionLastVersion.Models.Role", b =>
                {
                    b.Navigation("Membres");
                });
#pragma warning restore 612, 618
        }
    }
}
