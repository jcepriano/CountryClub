﻿// <auto-generated />
using System;
using CountryClubAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CountryClubAPI.Migrations
{
    [DbContext(typeof(CountryClubContext))]
    [Migration("20230920201251_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CountryClubAPI.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("FacilityId")
                        .HasColumnType("integer")
                        .HasColumnName("facility_id");

                    b.Property<int>("MemberId")
                        .HasColumnType("integer")
                        .HasColumnName("member_id");

                    b.Property<int>("Slots")
                        .HasColumnType("integer")
                        .HasColumnName("slots");

                    b.HasKey("Id")
                        .HasName("pk_bookings");

                    b.HasIndex("FacilityId")
                        .HasDatabaseName("ix_bookings_facility_id");

                    b.HasIndex("MemberId")
                        .HasDatabaseName("ix_bookings_member_id");

                    b.ToTable("bookings", (string)null);
                });

            modelBuilder.Entity("CountryClubAPI.Models.Facility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("GuestCost")
                        .HasColumnType("double precision")
                        .HasColumnName("guest_cost");

                    b.Property<double>("InitialOutlay")
                        .HasColumnType("double precision")
                        .HasColumnName("initial_outlay");

                    b.Property<double>("MemberCost")
                        .HasColumnType("double precision")
                        .HasColumnName("member_cost");

                    b.Property<double>("MonthlyMaintenance")
                        .HasColumnType("double precision")
                        .HasColumnName("monthly_maintenance");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_facilities");

                    b.ToTable("facilities", (string)null);
                });

            modelBuilder.Entity("CountryClubAPI.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("join_date");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<int?>("RecommendedBy")
                        .HasColumnType("integer")
                        .HasColumnName("recommended_by");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("telephone");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("zip_code");

                    b.HasKey("Id")
                        .HasName("pk_members");

                    b.ToTable("members", (string)null);
                });

            modelBuilder.Entity("CountryClubAPI.Models.Booking", b =>
                {
                    b.HasOne("CountryClubAPI.Models.Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_bookings_facilities_facility_id");

                    b.HasOne("CountryClubAPI.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_bookings_members_member_id");

                    b.Navigation("Facility");

                    b.Navigation("Member");
                });
#pragma warning restore 612, 618
        }
    }
}
