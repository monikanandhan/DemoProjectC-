﻿// <auto-generated />
using System;
using BankDemo.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BankDemo.Migrations
{
    [DbContext(typeof(BankDbContext))]
    [Migration("20230410050147_Banking")]
    partial class Banking
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BankDemo.Model.Customer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Aadhar")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Address2")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Contact1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("age")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.ToTable("customer");
                });

            modelBuilder.Entity("BankDemo.Model.Customer_Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("loanDetID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("loanDetID");

                    b.ToTable("customer_loan");
                });

            modelBuilder.Entity("BankDemo.Model.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("InterestRate")
                        .HasColumnType("float");

                    b.Property<int>("LoanTenure")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("loans");
                });

            modelBuilder.Entity("BankDemo.Model.Loan_details", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("LoanDetailsId")
                        .HasColumnType("int");

                    b.Property<int>("loanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LoanDetailsId");

                    b.HasIndex("loanId");

                    b.ToTable("loan_Details");
                });

            modelBuilder.Entity("BankDemo.Model.LoanDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("Amount")
                        .HasColumnType("float");

                    b.Property<int?>("Customerid")
                        .HasColumnType("int");

                    b.Property<DateTime>("LoanProvided")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("paymentMode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Customerid");

                    b.ToTable("loanDetails");
                });

            modelBuilder.Entity("BankDemo.Model.Customer_Loan", b =>
                {
                    b.HasOne("BankDemo.Model.Customer", "customer")
                        .WithMany("customer_Loans")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankDemo.Model.LoanDetails", "loandetails")
                        .WithMany("customer_Loans")
                        .HasForeignKey("loanDetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customer");

                    b.Navigation("loandetails");
                });

            modelBuilder.Entity("BankDemo.Model.Loan_details", b =>
                {
                    b.HasOne("BankDemo.Model.LoanDetails", "LoanDetails")
                        .WithMany("loandetailsDemo")
                        .HasForeignKey("LoanDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankDemo.Model.Loan", "loans")
                        .WithMany("loandetailsDemo")
                        .HasForeignKey("loanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoanDetails");

                    b.Navigation("loans");
                });

            modelBuilder.Entity("BankDemo.Model.LoanDetails", b =>
                {
                    b.HasOne("BankDemo.Model.Customer", null)
                        .WithMany("LoanDetails")
                        .HasForeignKey("Customerid");
                });

            modelBuilder.Entity("BankDemo.Model.Customer", b =>
                {
                    b.Navigation("LoanDetails");

                    b.Navigation("customer_Loans");
                });

            modelBuilder.Entity("BankDemo.Model.Loan", b =>
                {
                    b.Navigation("loandetailsDemo");
                });

            modelBuilder.Entity("BankDemo.Model.LoanDetails", b =>
                {
                    b.Navigation("customer_Loans");

                    b.Navigation("loandetailsDemo");
                });
#pragma warning restore 612, 618
        }
    }
}
