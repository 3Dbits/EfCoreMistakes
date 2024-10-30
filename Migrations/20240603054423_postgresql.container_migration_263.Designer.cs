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
    [Migration("20240603054423_postgresql.container_migration_263")]
    partial class postgresqlcontainer_migration_263
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

            modelBuilder.Entity("EfCoreMistakes.Models.SubSubModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("SubModelId")
                        .HasColumnType("integer");

                    b.Property<string>("SubSubInformation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SubModelId");

                    b.ToTable("SubSubModel");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            SubModelId = 1,
                            SubSubInformation = "SubSubmodel 1"
                        },
                        new
                        {
                            Id = 2,
                            SubModelId = 2,
                            SubSubInformation = "SubSubmodel 2"
                        },
                        new
                        {
                            Id = 3,
                            SubModelId = 3,
                            SubSubInformation = "SubSubmodel 3"
                        },
                        new
                        {
                            Id = 4,
                            SubModelId = 4,
                            SubSubInformation = "SubSubmodel 4"
                        },
                        new
                        {
                            Id = 5,
                            SubModelId = 5,
                            SubSubInformation = "SubSubmodel 5"
                        });
                });

            modelBuilder.Entity("EfCoreMistakes.Models.SubSubSubModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("SubSubModelId")
                        .HasColumnType("integer");

                    b.Property<string>("SubSubSubInformation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SubSubModelId");

                    b.ToTable("SubSubSubModel");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            SubSubModelId = 1,
                            SubSubSubInformation = "SubSubmodel 1"
                        },
                        new
                        {
                            Id = 2,
                            SubSubModelId = 2,
                            SubSubSubInformation = "SubSubmodel 2"
                        },
                        new
                        {
                            Id = 3,
                            SubSubModelId = 3,
                            SubSubSubInformation = "SubSubmodel 3"
                        },
                        new
                        {
                            Id = 4,
                            SubSubModelId = 4,
                            SubSubSubInformation = "SubSubmodel 4"
                        },
                        new
                        {
                            Id = 5,
                            SubSubModelId = 5,
                            SubSubSubInformation = "SubSubmodel 5"
                        });
                });

            modelBuilder.Entity("EfCoreMistakes.Models.SubModel", b =>
                {
                    b.HasOne("EfCoreMistakes.Models.SomeModel", "SomeModel")
                        .WithMany("SubModels")
                        .HasForeignKey("SomeModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SomeModel");
                });

            modelBuilder.Entity("EfCoreMistakes.Models.SubSubModel", b =>
                {
                    b.HasOne("EfCoreMistakes.Models.SubModel", "SubModel")
                        .WithMany("SubSubModels")
                        .HasForeignKey("SubModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubModel");
                });

            modelBuilder.Entity("EfCoreMistakes.Models.SubSubSubModel", b =>
                {
                    b.HasOne("EfCoreMistakes.Models.SubSubModel", "SubSubModel")
                        .WithMany("SubSubSubModels")
                        .HasForeignKey("SubSubModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubSubModel");
                });

            modelBuilder.Entity("EfCoreMistakes.Models.SomeModel", b =>
                {
                    b.Navigation("SubModels");
                });

            modelBuilder.Entity("EfCoreMistakes.Models.SubModel", b =>
                {
                    b.Navigation("SubSubModels");
                });

            modelBuilder.Entity("EfCoreMistakes.Models.SubSubModel", b =>
                {
                    b.Navigation("SubSubSubModels");
                });
#pragma warning restore 612, 618
        }
    }
}
