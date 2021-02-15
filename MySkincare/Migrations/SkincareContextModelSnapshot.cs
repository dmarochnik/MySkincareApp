﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MySkincare.Models;

namespace MySkincare.Migrations
{
    [DbContext(typeof(SkincareContext))]
    partial class SkincareContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MySkincare.Models.Login", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<int>("UID")
                        .HasColumnType("int");

                    b.HasKey("Email");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("MySkincare.Models.QuizAnswer", b =>
                {
                    b.Property<int>("AID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Answer")
                        .HasColumnType("text");

                    b.Property<int>("QID")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("AID");

                    b.HasIndex("QID");

                    b.ToTable("QuizAnswers");
                });

            modelBuilder.Entity("MySkincare.Models.QuizQuestion", b =>
                {
                    b.Property<int>("QID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Question")
                        .HasColumnType("text");

                    b.HasKey("QID");

                    b.ToTable("QuizQuestions");
                });

            modelBuilder.Entity("MySkincare.Models.User", b =>
                {
                    b.Property<int>("UID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("FName")
                        .HasColumnType("text");

                    b.Property<string>("LName")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNum")
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("text");

                    b.Property<string>("ZIP")
                        .HasColumnType("text");

                    b.HasKey("UID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MySkincare.Models.QuizAnswer", b =>
                {
                    b.HasOne("MySkincare.Models.QuizQuestion", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
