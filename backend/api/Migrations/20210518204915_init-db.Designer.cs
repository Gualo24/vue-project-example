﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.models;

namespace api.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210518204915_init-db")]
    partial class initdb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("api.models.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmployeeLastName")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("EmployeeNames")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("PermissionDate")
                        .HasColumnType("DateTime");

                    b.Property<int>("PermissionType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PermissionType");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("api.models.PermissionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("PermissionTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Enfermedad,"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Diligencias"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Otros."
                        });
                });

            modelBuilder.Entity("api.models.Permission", b =>
                {
                    b.HasOne("api.models.PermissionType", "Type")
                        .WithMany("Permissions")
                        .HasForeignKey("PermissionType")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("api.models.PermissionType", b =>
                {
                    b.Navigation("Permissions");
                });
#pragma warning restore 612, 618
        }
    }
}
