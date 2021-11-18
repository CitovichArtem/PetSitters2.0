﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Petsitters.Persistence;

namespace Petsitters.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211118142537_1st")]
    partial class _1st
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("Petsitters.Domain.Bid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("MyServiceId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PetId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("MyServiceId");

                    b.HasIndex("PetId");

                    b.ToTable("Bids");
                });

            modelBuilder.Entity("Petsitters.Domain.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<short>("Mark")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OwnerUserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.Property<int?>("WorkerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WorkerUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("OwnerId");

                    b.HasIndex("WorkerId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("Petsitters.Domain.MyService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Details")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("MyServices");
                });

            modelBuilder.Entity("Petsitters.Domain.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BidId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("Petsitters.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Petsitters.Domain.Bid", b =>
                {
                    b.HasOne("Petsitters.Domain.MyService", "MyService")
                        .WithMany("Bids")
                        .HasForeignKey("MyServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Petsitters.Domain.Pet", "Pet")
                        .WithMany("Bids")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MyService");

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("Petsitters.Domain.Feedback", b =>
                {
                    b.HasOne("Petsitters.Domain.User", "Owner")
                        .WithMany("FeedbacksLeftByMe")
                        .HasForeignKey("OwnerId");

                    b.HasOne("Petsitters.Domain.User", "Worker")
                        .WithMany("FeedbacksAboutMe")
                        .HasForeignKey("WorkerId");

                    b.Navigation("Owner");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("Petsitters.Domain.MyService", b =>
                {
                    b.HasOne("Petsitters.Domain.User", "Worker")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("Petsitters.Domain.Pet", b =>
                {
                    b.HasOne("Petsitters.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Petsitters.Domain.MyService", b =>
                {
                    b.Navigation("Bids");
                });

            modelBuilder.Entity("Petsitters.Domain.Pet", b =>
                {
                    b.Navigation("Bids");
                });

            modelBuilder.Entity("Petsitters.Domain.User", b =>
                {
                    b.Navigation("FeedbacksAboutMe");

                    b.Navigation("FeedbacksLeftByMe");
                });
#pragma warning restore 612, 618
        }
    }
}
