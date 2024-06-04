﻿// <auto-generated />
using System;
using BadmintonRentalSWD.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BadmintonRentalSWD.Migrations
{
    [DbContext(typeof(BBMSDbContext))]
    [Migration("20240603025042_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("BookingTypeId")
                        .HasColumnType("integer");

                    b.Property<int?>("CheckinBy")
                        .HasColumnType("integer");

                    b.Property<int?>("CheckoutBy")
                        .HasColumnType("integer");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CourtId")
                        .HasColumnType("integer");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int?>("FlexibleBookingId")
                        .HasColumnType("integer");

                    b.Property<TimeOnly>("FromTime")
                        .HasColumnType("time without time zone");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeOnly>("ToTime")
                        .HasColumnType("time without time zone");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BookingTypeId");

                    b.HasIndex("CourtId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("FlexibleBookingId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.BookingDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BookingId")
                        .HasColumnType("integer");

                    b.Property<int>("CourtSlotId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.HasIndex("CourtSlotId");

                    b.ToTable("BookingDetail");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.BookingType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("BookingType");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Balance")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.ContactPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CourtGroupId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CourtGroupId");

                    b.ToTable("ContactPoint");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.Court", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CourtGroupId")
                        .HasColumnType("integer");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CourtGroupId");

                    b.ToTable("Court");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.CourtGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer");

                    b.Property<string>("CoverImage")
                        .HasColumnType("text");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeOnly>("EndTime")
                        .HasColumnType("time without time zone");

                    b.Property<string>("FromDay")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("text");

                    b.Property<float?>("Rate")
                        .HasColumnType("real");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("time without time zone");

                    b.Property<string>("ToDay")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("CourtGroup");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.CourtSlot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CourtGroupId")
                        .HasColumnType("integer");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeOnly>("FromTime")
                        .HasColumnType("time without time zone");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeOnly>("ToTime")
                        .HasColumnType("time without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CourtGroupId");

                    b.ToTable("CourtSlot");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<int>("CourtGroupId")
                        .HasColumnType("integer");

                    b.Property<float>("Rate")
                        .HasColumnType("real");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CourtGroupId");

                    b.HasIndex("UserId");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.FlexibleBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("ExpiredDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("IssuedDate")
                        .HasColumnType("date");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("RemainingHours")
                        .HasColumnType("integer");

                    b.Property<int>("TotalHours")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("FlexibleBooking");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<long>("Amount")
                        .HasColumnType("bigint");

                    b.Property<int>("BookingId")
                        .HasColumnType("integer");

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BookingId")
                        .IsUnique();

                    b.HasIndex("CompanyId");

                    b.HasIndex("PaymentMethodId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("MethodName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("PaymentMethod");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.Price", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BookingTypeId")
                        .HasColumnType("integer");

                    b.Property<long>("Cost")
                        .HasColumnType("bigint");

                    b.Property<int>("CourtSlotId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BookingTypeId");

                    b.HasIndex("CourtSlotId");

                    b.ToTable("Price");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CourtGroupId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CourtGroupId");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CompanyId")
                        .HasColumnType("integer");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.Withdraw", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<long>("Amount")
                        .HasColumnType("bigint");

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Withdraw");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.Booking", b =>
                {
                    b.HasOne("BadmintonRentalSWD.BusinessObjects.BookingType", null)
                        .WithMany("Bookings")
                        .HasForeignKey("BookingTypeId");

                    b.HasOne("BadmintonRentalSWD.BusinessObjects.Court", "Court")
                        .WithMany("Bookings")
                        .HasForeignKey("CourtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BadmintonRentalSWD.BusinessObjects.Customer", "Customer")
                        .WithMany("Bookings")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BadmintonRentalSWD.BusinessObjects.FlexibleBooking", "FlexibleBooking")
                        .WithMany("Bookings")
                        .HasForeignKey("FlexibleBookingId");

                    b.Navigation("Court");

                    b.Navigation("Customer");

                    b.Navigation("FlexibleBooking");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.BookingDetail", b =>
                {
                    b.HasOne("BadmintonRentalSWD.BusinessObjects.Booking", "Booking")
                        .WithMany("BookingDetails")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BadmintonRentalSWD.BusinessObjects.CourtSlot", "CourtSlot")
                        .WithMany("BookingDetails")
                        .HasForeignKey("CourtSlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("CourtSlot");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.ContactPoint", b =>
                {
                    b.HasOne("BadmintonRentalSWD.BusinessObjects.CourtGroup", "CourtGroup")
                        .WithMany("ContactPoints")
                        .HasForeignKey("CourtGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourtGroup");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.Court", b =>
                {
                    b.HasOne("BadmintonRentalSWD.BusinessObjects.CourtGroup", "CourtGroup")
                        .WithMany("Courts")
                        .HasForeignKey("CourtGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourtGroup");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.CourtGroup", b =>
                {
                    b.HasOne("BadmintonRentalSWD.BusinessObjects.Company", "Company")
                        .WithMany("CourtGroups")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.CourtSlot", b =>
                {
                    b.HasOne("BadmintonRentalSWD.BusinessObjects.CourtGroup", "CourtGroup")
                        .WithMany("CourtSlots")
                        .HasForeignKey("CourtGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourtGroup");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.Feedback", b =>
                {
                    b.HasOne("BadmintonRentalSWD.BusinessObjects.CourtGroup", "CourtGroup")
                        .WithMany("Feedbacks")
                        .HasForeignKey("CourtGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BadmintonRentalSWD.BusinessObjects.User", "User")
                        .WithMany("Feedbacks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourtGroup");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.FlexibleBooking", b =>
                {
                    b.HasOne("BadmintonRentalSWD.BusinessObjects.Customer", "Customer")
                        .WithMany("FlexibleBookings")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.Payment", b =>
                {
                    b.HasOne("BadmintonRentalSWD.BusinessObjects.Booking", "Booking")
                        .WithOne("Payment")
                        .HasForeignKey("BadmintonRentalSWD.BusinessObjects.Payment", "BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BadmintonRentalSWD.BusinessObjects.Company", "Company")
                        .WithMany("Payments")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BadmintonRentalSWD.BusinessObjects.PaymentMethod", "PaymentMethod")
                        .WithMany("Payments")
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("Company");

                    b.Navigation("PaymentMethod");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.Price", b =>
                {
                    b.HasOne("BadmintonRentalSWD.BusinessObjects.BookingType", "BookingType")
                        .WithMany("Prices")
                        .HasForeignKey("BookingTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BadmintonRentalSWD.BusinessObjects.CourtSlot", "CourtSlot")
                        .WithMany("Prices")
                        .HasForeignKey("CourtSlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookingType");

                    b.Navigation("CourtSlot");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.Service", b =>
                {
                    b.HasOne("BadmintonRentalSWD.BusinessObjects.CourtGroup", "CourtGroup")
                        .WithMany("Services")
                        .HasForeignKey("CourtGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourtGroup");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.User", b =>
                {
                    b.HasOne("BadmintonRentalSWD.BusinessObjects.Company", "Company")
                        .WithMany("Users")
                        .HasForeignKey("CompanyId");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.Withdraw", b =>
                {
                    b.HasOne("BadmintonRentalSWD.BusinessObjects.Company", "Company")
                        .WithMany("Withdraws")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.Booking", b =>
                {
                    b.Navigation("BookingDetails");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.BookingType", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Prices");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.Company", b =>
                {
                    b.Navigation("CourtGroups");

                    b.Navigation("Payments");

                    b.Navigation("Users");

                    b.Navigation("Withdraws");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.Court", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.CourtGroup", b =>
                {
                    b.Navigation("ContactPoints");

                    b.Navigation("CourtSlots");

                    b.Navigation("Courts");

                    b.Navigation("Feedbacks");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.CourtSlot", b =>
                {
                    b.Navigation("BookingDetails");

                    b.Navigation("Prices");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.Customer", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("FlexibleBookings");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.FlexibleBooking", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.PaymentMethod", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("BadmintonRentalSWD.BusinessObjects.User", b =>
                {
                    b.Navigation("Feedbacks");
                });
#pragma warning restore 612, 618
        }
    }
}