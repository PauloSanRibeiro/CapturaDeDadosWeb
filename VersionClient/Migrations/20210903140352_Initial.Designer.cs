﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VersionClient.Models;

namespace VersionClient.Migrations
{
    [DbContext(typeof(VersionContext))]
    [Migration("20210903140352_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("VersionClient.Models.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NameClient")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UrlLogin")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("IdClient");

                    b.ToTable("Client");
                });
#pragma warning restore 612, 618
        }
    }
}