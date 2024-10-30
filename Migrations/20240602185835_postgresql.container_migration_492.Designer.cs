﻿// <auto-generated />
using EfCoreMistakes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EfCoreMistakes.Migrations
{
    [DbContext(typeof(EfCoreMistakesContext))]
    [Migration("20240602185835_postgresql.container_migration_492")]
    partial class postgresqlcontainer_migration_492
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EfCoreMistakes.Models.SomeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SomeModel");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "SomeModel 1"
                        },
                        new
                        {
                            Id = 2,
                            Title = "SomeModel 2"
                        });
                });

            modelBuilder.Entity("EfCoreMistakes.Models.SubModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Information")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SomeModelId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SomeModelId");

                    b.ToTable("SubModel");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Information = "Submodel 1",
                            SomeModelId = 1
                        },
                        new
                        {
                            Id = 2,
                            Information = "Submodel 2",
                            SomeModelId = 1
                        },
                        new
                        {
                            Id = 3,
                            Information = "Submodel 3",
                            SomeModelId = 2
                        },
                        new
                        {
                            Id = 4,
                            Information = "Submodel 4",
                            SomeModelId = 2
                        },
                        new
                        {
                            Id = 5,
                            Information = "Submodel 5",
                            SomeModelId = 2
                        });
                });

            modelBuilder.Entity("EfCoreMistakes.Models.SubModel", b =>
                {
                    b.HasOne("EfCoreMistakes.Models.SomeModel", null)
                        .WithMany("SubModels")
                        .HasForeignKey("SomeModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EfCoreMistakes.Models.SomeModel", b =>
                {
                    b.Navigation("SubModels");
                });
#pragma warning restore 612, 618
        }
    }
}
