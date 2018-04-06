﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using QuizDataLibrary;
using System;

namespace QuizDataLibrary.Migrations
{
    [DbContext(typeof(QuizTakerDbContext))]
    [Migration("20180405221345_change")]
    partial class change
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QuizDataLibrary.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answers");

                    b.Property<bool>("IsCorrect");

                    b.Property<int>("QuestionId");

                    b.Property<int?>("QuizId");

                    b.HasKey("AnswerId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("QuizId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("QuizDataLibrary.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Questions");

                    b.Property<int?>("QuizId");

                    b.HasKey("QuestionId");

                    b.HasIndex("QuizId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("QuizDataLibrary.Quiz", b =>
                {
                    b.Property<int>("QuizId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<DateTime>("PublishDate");

                    b.Property<string>("Title");

                    b.HasKey("QuizId");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("QuizDataLibrary.Answer", b =>
                {
                    b.HasOne("QuizDataLibrary.Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QuizDataLibrary.Quiz")
                        .WithMany("Answers")
                        .HasForeignKey("QuizId");
                });

            modelBuilder.Entity("QuizDataLibrary.Question", b =>
                {
                    b.HasOne("QuizDataLibrary.Quiz")
                        .WithMany("Questions")
                        .HasForeignKey("QuizId");
                });
#pragma warning restore 612, 618
        }
    }
}
