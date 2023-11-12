﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RecapApi.Repositories;

#nullable disable

namespace RecapApi.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20231112021118_Mig_005")]
    partial class Mig_005
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RecapApi.Entities.Company", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now() at time zone 'utc'")
                        .HasAnnotation("Relational:JsonPropertyName", "created_at");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasAnnotation("Relational:JsonPropertyName", "is_deleted");

                    b.Property<DateTime>("ModifiedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now() at time zone 'utc'")
                        .HasAnnotation("Relational:JsonPropertyName", "modified_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("RecapApi.Entities.Employee", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<int>("Age")
                        .HasColumnType("integer")
                        .HasAnnotation("Relational:JsonPropertyName", "age");

                    b.Property<string>("CompanyId")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now() at time zone 'utc'")
                        .HasAnnotation("Relational:JsonPropertyName", "created_at");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasAnnotation("Relational:JsonPropertyName", "is_deleted");

                    b.Property<DateTime>("ModifiedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now() at time zone 'utc'")
                        .HasAnnotation("Relational:JsonPropertyName", "modified_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasAnnotation("Relational:JsonPropertyName", "position");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = "emp_OnJez6Izc26tBz",
                            Age = 26,
                            CreatedAt = new DateTime(2023, 11, 12, 2, 11, 18, 632, DateTimeKind.Utc).AddTicks(3220),
                            IsDeleted = false,
                            ModifiedAt = new DateTime(2023, 11, 12, 2, 11, 18, 632, DateTimeKind.Utc).AddTicks(3220),
                            Name = "Tonoy Akanda",
                            Position = "Founder & CTO"
                        });
                });

            modelBuilder.Entity("RecapApi.Entities.Employee", b =>
                {
                    b.HasOne("RecapApi.Entities.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("RecapApi.Entities.Company", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
