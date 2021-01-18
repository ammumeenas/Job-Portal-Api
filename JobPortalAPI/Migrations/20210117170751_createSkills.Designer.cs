﻿// <auto-generated />
using JobPortalAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JobPortalAPI.Migrations
{
    [DbContext(typeof(JobDbContext))]
    [Migration("20210117170751_createSkills")]
    partial class createSkills
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("JobPortalAPI.Models.Job", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("company")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("jobLocation")
                        .HasColumnType("TEXT");

                    b.Property<int>("noOfApplicants")
                        .HasColumnType("INTEGER");

                    b.Property<int>("noOfOpenings")
                        .HasColumnType("INTEGER");

                    b.Property<string>("role")
                        .HasColumnType("TEXT");

                    b.Property<int>("yearsOfExperience")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("JobPortalAPI.Models.JobSkill", b =>
                {
                    b.Property<int>("JobId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SkillId")
                        .HasColumnType("INTEGER");

                    b.HasKey("JobId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("JobSkill");
                });

            modelBuilder.Entity("JobPortalAPI.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("JobPortalAPI.Models.JobSkill", b =>
                {
                    b.HasOne("JobPortalAPI.Models.Job", "Job")
                        .WithMany("JobSkills")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobPortalAPI.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("JobPortalAPI.Models.Job", b =>
                {
                    b.Navigation("JobSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
