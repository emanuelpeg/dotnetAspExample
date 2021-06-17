﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dotnetAspExample;

namespace dotnetAspExample.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20210617152718_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("dotnetAspExample.Artista", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("fechaNacimiento")
                        .HasColumnType("TEXT");

                    b.Property<string>("nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Artistas");
                });

            modelBuilder.Entity("dotnetAspExample.Disco", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("Artistaid")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("fechaLanzamiento")
                        .HasColumnType("TEXT");

                    b.Property<string>("nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("Artistaid");

                    b.ToTable("Discos");
                });

            modelBuilder.Entity("dotnetAspExample.Disco", b =>
                {
                    b.HasOne("dotnetAspExample.Artista", null)
                        .WithMany("discos")
                        .HasForeignKey("Artistaid");
                });

            modelBuilder.Entity("dotnetAspExample.Artista", b =>
                {
                    b.Navigation("discos");
                });
#pragma warning restore 612, 618
        }
    }
}