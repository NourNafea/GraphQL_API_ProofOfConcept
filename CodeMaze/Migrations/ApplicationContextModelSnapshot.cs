﻿// <auto-generated />
using System;
using CodeMaze.Entities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CodeMaze.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CodeMaze.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bdbb84ba-6989-4113-917c-68916fb2dba1"),
                            Description = "Cash account for our users",
                            OwnerId = new Guid("031ceeb7-49b3-456a-b81c-02321fd3ff5b"),
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("e68ac22b-7ee9-4474-8f83-f87cb65b2cb4"),
                            Description = "Savings account for our users",
                            OwnerId = new Guid("ecfa70cd-d028-4eb9-a8c4-31a744f2396a"),
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("8b513f04-2a77-47b1-b3eb-fdc2e090e4c1"),
                            Description = "Income account for our users",
                            OwnerId = new Guid("ecfa70cd-d028-4eb9-a8c4-31a744f2396a"),
                            Type = 3
                        });
                });

            modelBuilder.Entity("CodeMaze.Entities.Owner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Owners");

                    b.HasData(
                        new
                        {
                            Id = new Guid("031ceeb7-49b3-456a-b81c-02321fd3ff5b"),
                            Address = "John Doe's address",
                            Name = "John Doe"
                        },
                        new
                        {
                            Id = new Guid("ecfa70cd-d028-4eb9-a8c4-31a744f2396a"),
                            Address = "Jane Doe's address",
                            Name = "Jane Doe"
                        });
                });

            modelBuilder.Entity("CodeMaze.Entities.Account", b =>
                {
                    b.HasOne("CodeMaze.Entities.Owner", "Owner")
                        .WithMany("Accounts")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("CodeMaze.Entities.Owner", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}