﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskSolution.DAL.Data;

#nullable disable

namespace TaskSolution.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230724143051_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaskSolution.DAL.Models.TravelPoint", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TravelRouteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("TravelPoints");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b6fda7de-e180-47d0-a49b-6a5013150280"),
                            Name = "Alabama",
                            TravelRouteId = new Guid("b6fda7de-e180-47d0-a49b-6a5013150280")
                        },
                        new
                        {
                            Id = new Guid("674968a2-8684-48ac-a8da-23a230dc9d87"),
                            Name = "San-Francisco",
                            TravelRouteId = new Guid("b6fda7de-e180-47d0-a49b-6a5013150280")
                        },
                        new
                        {
                            Id = new Guid("72bc2a1d-d029-492d-a008-0c0e2540b7c4"),
                            Name = "Washington",
                            TravelRouteId = new Guid("674968a2-8684-48ac-a8da-23a230dc9d87")
                        },
                        new
                        {
                            Id = new Guid("d7a64d76-2ba3-42a1-b412-96fc89bec6a4"),
                            Name = "Ohaio",
                            TravelRouteId = new Guid("b6fda7de-e180-47d0-a49b-6a5013150280")
                        });
                });

            modelBuilder.Entity("TaskSolution.DAL.Models.TravelRoute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ArrivalDateTimeUTC")
                        .HasColumnType("datetime2");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<Guid?>("EndPointId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDateTimeUTC")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("StartPointId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("TimeToLive")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EndPointId");

                    b.HasIndex("StartPointId");

                    b.ToTable("TravelRoutes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("571de9b2-a818-403a-a2bb-cea966971456"),
                            ArrivalDateTimeUTC = new DateTime(2023, 2, 15, 2, 0, 0, 0, DateTimeKind.Utc),
                            Cost = 25,
                            EndPointId = new Guid("674968a2-8684-48ac-a8da-23a230dc9d87"),
                            StartDateTimeUTC = new DateTime(2023, 2, 15, 4, 0, 0, 0, DateTimeKind.Utc),
                            StartPointId = new Guid("b6fda7de-e180-47d0-a49b-6a5013150280"),
                            TimeToLive = 108000000000L
                        },
                        new
                        {
                            Id = new Guid("a70eeb33-1be3-48b2-960f-11f57b1e3084"),
                            ArrivalDateTimeUTC = new DateTime(2023, 2, 15, 2, 0, 0, 0, DateTimeKind.Utc),
                            Cost = 29,
                            EndPointId = new Guid("674968a2-8684-48ac-a8da-23a230dc9d87"),
                            StartDateTimeUTC = new DateTime(2023, 2, 15, 4, 0, 0, 0, DateTimeKind.Utc),
                            StartPointId = new Guid("b6fda7de-e180-47d0-a49b-6a5013150280"),
                            TimeToLive = 72000000000L
                        },
                        new
                        {
                            Id = new Guid("7f85b28d-9f8b-4a0a-9b15-0c046995d3fa"),
                            ArrivalDateTimeUTC = new DateTime(2023, 2, 15, 2, 0, 0, 0, DateTimeKind.Utc),
                            Cost = 70,
                            EndPointId = new Guid("674968a2-8684-48ac-a8da-23a230dc9d87"),
                            StartDateTimeUTC = new DateTime(2023, 2, 15, 4, 0, 0, 0, DateTimeKind.Utc),
                            StartPointId = new Guid("b6fda7de-e180-47d0-a49b-6a5013150280"),
                            TimeToLive = 18000000000L
                        });
                });

            modelBuilder.Entity("TaskSolution.DAL.Models.TravelRoute", b =>
                {
                    b.HasOne("TaskSolution.DAL.Models.TravelPoint", "EndPoint")
                        .WithMany()
                        .HasForeignKey("EndPointId");

                    b.HasOne("TaskSolution.DAL.Models.TravelPoint", "StartPoint")
                        .WithMany()
                        .HasForeignKey("StartPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EndPoint");

                    b.Navigation("StartPoint");
                });
#pragma warning restore 612, 618
        }
    }
}