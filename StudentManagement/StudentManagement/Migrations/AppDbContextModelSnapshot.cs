﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentManagement.Model;

#nullable disable

namespace StudentManagement.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("StudentManagement.Model.Mark_Details", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Chemistry")
                        .HasColumnType("int");

                    b.Property<int>("ComputerScience")
                        .HasColumnType("int");

                    b.Property<int>("English")
                        .HasColumnType("int");

                    b.Property<int>("Maths")
                        .HasColumnType("int");

                    b.Property<int>("Tamil")
                        .HasColumnType("int");

                    b.Property<int>("TermId")
                        .HasColumnType("int");

                    b.Property<int>("physics")
                        .HasColumnType("int");

                    b.Property<int>("studentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TermId");

                    b.HasIndex("studentId");

                    b.ToTable("Marks");
                });

            modelBuilder.Entity("StudentManagement.Model.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Academic_Year")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("RollNo")
                        .HasColumnType("int");

                    b.Property<int>("standard")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentManagement.Model.Term", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("TermName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Term");
                });

            modelBuilder.Entity("StudentManagement.Model.Mark_Details", b =>
                {
                    b.HasOne("StudentManagement.Model.Term", "Term")
                        .WithMany()
                        .HasForeignKey("TermId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentManagement.Model.Student", "Student")
                        .WithMany()
                        .HasForeignKey("studentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Term");
                });
#pragma warning restore 612, 618
        }
    }
}
