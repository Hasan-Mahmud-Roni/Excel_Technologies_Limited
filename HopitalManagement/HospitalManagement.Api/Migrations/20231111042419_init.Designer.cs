﻿// <auto-generated />
using System;
using HospitalManagement.Api.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HospitalManagement.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231111042419_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HospitalManagment.Library.Domain.Allergies", b =>
                {
                    b.Property<int>("AllergiesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AllergiesID"));

                    b.Property<string>("AllergiesName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.HasKey("AllergiesID");

                    b.HasIndex("PatientID");

                    b.ToTable("Allergiess");
                });

            modelBuilder.Entity("HospitalManagment.Library.Domain.Allergies_Details", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("AllergiesID")
                        .HasColumnType("int");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("AllergiesDetails");
                });

            modelBuilder.Entity("HospitalManagment.Library.Domain.Disease", b =>
                {
                    b.Property<int>("DiseaseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiseaseID"));

                    b.Property<string>("DiseaseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DiseaseID");

                    b.ToTable("Diseases");
                });

            modelBuilder.Entity("HospitalManagment.Library.Domain.NCD", b =>
                {
                    b.Property<int>("NCDID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NCDID"));

                    b.Property<string>("NCDName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.HasKey("NCDID");

                    b.HasIndex("PatientID");

                    b.ToTable("NCDs");
                });

            modelBuilder.Entity("HospitalManagment.Library.Domain.NCD_Details", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("NCDID")
                        .HasColumnType("int");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("NCDsDetails");
                });

            modelBuilder.Entity("HospitalManagment.Library.Domain.Patient", b =>
                {
                    b.Property<int>("PatientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientID"));

                    b.Property<int>("DiseaseID")
                        .HasColumnType("int");

                    b.Property<int>("Epilepsy")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientID");

                    b.HasIndex("DiseaseID");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("HospitalManagment.Library.Domain.Allergies", b =>
                {
                    b.HasOne("HospitalManagment.Library.Domain.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalManagment.Library.Domain.NCD", b =>
                {
                    b.HasOne("HospitalManagment.Library.Domain.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalManagment.Library.Domain.Patient", b =>
                {
                    b.HasOne("HospitalManagment.Library.Domain.Disease", "Disease")
                        .WithMany("Patients")
                        .HasForeignKey("DiseaseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disease");
                });

            modelBuilder.Entity("HospitalManagment.Library.Domain.Disease", b =>
                {
                    b.Navigation("Patients");
                });
#pragma warning restore 612, 618
        }
    }
}