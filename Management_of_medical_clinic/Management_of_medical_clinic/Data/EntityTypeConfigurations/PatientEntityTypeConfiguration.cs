﻿using Console_Management_of_medical_clinic.Data.Enums;
using Console_Management_of_medical_clinic.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Console_Management_of_medical_clinic.Data.EntityTypeConfigurations
{
    public class PatientEntityTypeConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder
                .ToTable("Patient");

            builder
                .HasKey(p => p.PatientId);

            builder
                .HasCheckConstraint("CK_Person_BirthDate", "DateOfBirth <= date('now')");

            builder
                .HasCheckConstraint("CK_PESEL", "PESEL REGEXP '^[0-9]{11}$'");


            #region Patient Properties Configuration

            builder
                .Property(p => p.PatientId)
                .IsRequired()
                .HasColumnName("IdPatient")
                .ValueGeneratedOnAdd();

            builder
                .Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("FirstName")
                .HasMaxLength(60);

            builder
                .Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("LastName")
                .HasMaxLength(60);

            builder
                .Property(p => p.BirthDate)
                .IsRequired()
                .HasColumnName("DateOfBirth");

            builder
                .Property(p => p.PESEL)
                .IsRequired()
                .HasColumnName("PESEL")
                .HasMaxLength(11);

            builder
                .Property(p => p.IsActive)
                .IsRequired()
                .HasColumnName("IsActive")
                .HasConversion(new BoolToZeroOneConverter<short>());

            builder
                .Property(p => p.Sex)
                .IsRequired()
                .HasConversion(new EnumToNumberConverter<EnumSex, int>());

            builder
                .Property(p => p.LastVistiDate)
                .IsRequired(false)
                .HasColumnName("DateLastVisit")
                .HasComputedColumnSql("(SELECT MAX(Date) FROM Visits WHERE PatientId = Id AND Date <= DATE('now'))");
                // Alternative solution:
                // Visits?.Where(v => v.Date <= DateTime.Today).OrderByDescending(v => v.Date).FirstOrDefault()?.Date;


            #endregion
        }
    }
}
