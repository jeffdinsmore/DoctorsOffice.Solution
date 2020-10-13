﻿// <auto-generated />
using DoctorsOffice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DoctorsOffice.Migrations
{
    [DbContext(typeof(DoctorsOfficeContext))]
    [Migration("20201013220400_fifth")]
    partial class fifth
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DoctorsOffice.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("DoctorId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("DoctorsOffice.Models.DoctorPatient", b =>
                {
                    b.Property<int>("DoctorPatientId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DoctorId");

                    b.Property<int>("PatientId");

                    b.HasKey("DoctorPatientId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("DoctorPatient");
                });

            modelBuilder.Entity("DoctorsOffice.Models.DoctorSpecialty", b =>
                {
                    b.Property<int>("DoctorSpecialtyId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DoctorId");

                    b.Property<int>("SpecialtyId");

                    b.HasKey("DoctorSpecialtyId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("SpecialtyId");

                    b.ToTable("DoctorSpecialty");
                });

            modelBuilder.Entity("DoctorsOffice.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Birthdate");

                    b.Property<string>("PatientName");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("DoctorsOffice.Models.Specialty", b =>
                {
                    b.Property<int>("SpecialtyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SpecialtyName");

                    b.HasKey("SpecialtyId");

                    b.ToTable("Specialties");
                });

            modelBuilder.Entity("DoctorsOffice.Models.DoctorPatient", b =>
                {
                    b.HasOne("DoctorsOffice.Models.Doctor", "Doctor")
                        .WithMany("Patients")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DoctorsOffice.Models.Patient", "Patient")
                        .WithMany("Doctors")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DoctorsOffice.Models.DoctorSpecialty", b =>
                {
                    b.HasOne("DoctorsOffice.Models.Doctor", "Doctor")
                        .WithMany("Specialties")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DoctorsOffice.Models.Specialty", "Specialty")
                        .WithMany("Doctors")
                        .HasForeignKey("SpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}