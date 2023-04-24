﻿// <auto-generated />
using System;
using Console_Management_of_medical_clinic.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Console_Management_of_medical_clinic.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("Console_Management_of_medical_clinic.Model.EmployeeModel", b =>
                {
                    b.Property<int>("IdEmployee")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CorrespondenceAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("DateOfBirth")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("IdSpecialization")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PESEL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Sex")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdEmployee");

                    b.HasIndex("IdSpecialization");

                    b.ToTable("DbEmployees");
                });

            modelBuilder.Entity("Console_Management_of_medical_clinic.Model.SpecializationModel", b =>
                {
                    b.Property<int>("IdSpecialization")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdSpecialization");

                    b.ToTable("DbSpecializations");
                });

            modelBuilder.Entity("Console_Management_of_medical_clinic.Model.UserModel", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdEmployee")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdUser");

                    b.HasIndex("IdEmployee")
                        .IsUnique();

                    b.ToTable("DbUsers");
                });

            modelBuilder.Entity("Console_Management_of_medical_clinic.Model.Visit", b =>
                {
                    b.Property<int>("VisitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("IdVisit");

                    b.Property<decimal>("Cost")
                        .HasColumnType("TEXT")
                        .HasColumnName("CostVisit");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("IdEmployee");

                    b.Property<int?>("PatientId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("IdPatient");

                    b.Property<DateTime>("VisitDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("DateVisit");

                    b.Property<DateTime>("VisitHour")
                        .HasColumnType("TEXT")
                        .HasColumnName("HourVisit");

                    b.HasKey("VisitId");

                    b.HasIndex("PatientId");

                    b.ToTable("Visit");
                });

            modelBuilder.Entity("Console_Management_of_medical_clinic.Model.EmployeeModel", b =>
                {
                    b.HasOne("Console_Management_of_medical_clinic.Model.SpecializationModel", "SpecializationModel")
                        .WithMany("EmployeeModels")
                        .HasForeignKey("IdSpecialization");

                    b.Navigation("SpecializationModel");
                });

            modelBuilder.Entity("Console_Management_of_medical_clinic.Model.OfficeModel", b =>
                {
                    b.HasOne("Console_Management_of_medical_clinic.Model.SpecializationModel", "SpecializationModel")
                        .WithMany("officeModels")
                        .HasForeignKey("IdSpecialization")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SpecializationModel");
                });

            modelBuilder.Entity("Console_Management_of_medical_clinic.Model.UserModel", b =>
                {
                    b.HasOne("Console_Management_of_medical_clinic.Model.EmployeeModel", "EmployeeModel")
                        .WithOne("UserModel")
                        .HasForeignKey("Console_Management_of_medical_clinic.Model.UserModel", "IdEmployee")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeModel");
                });

            modelBuilder.Entity("Console_Management_of_medical_clinic.Model.Visit", b =>
                {
                    b.HasOne("Console_Management_of_medical_clinic.Model.EmployeeModel", "Employee")
                        .WithMany("Visits")
                        .HasForeignKey("PatientId");

                    b.HasOne("Console_Management_of_medical_clinic.Model.Patient", "Patient")
                        .WithMany("Visits")
                        .HasForeignKey("PatientId");

                    b.Navigation("Employee");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Console_Management_of_medical_clinic.Model.EmployeeModel", b =>
                {
                    b.Navigation("UserModel");

                    b.Navigation("Visits");
                });

            modelBuilder.Entity("Console_Management_of_medical_clinic.Model.Patient", b =>
                {
                    b.Navigation("Visits");
                });

            modelBuilder.Entity("Console_Management_of_medical_clinic.Model.SpecializationModel", b =>
                {
                    b.Navigation("EmployeeModels");

                    b.Navigation("officeModels");
                });
#pragma warning restore 612, 618
        }
    }
}
