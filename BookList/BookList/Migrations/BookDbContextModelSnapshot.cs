﻿// <auto-generated />
using System;
using BookList.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookList.Migrations
{
    [DbContext(typeof(BookDbContext))]
    partial class BookDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("BookList.Model.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AuthorName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("author");
                });

            modelBuilder.Entity("BookList.Model.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CoverUrl")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateRead")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Genere")
                        .HasColumnType("text");

                    b.Property<bool>("IsRead")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<int?>("Rate")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PublisherId");

                    b.ToTable("books");
                });

            modelBuilder.Entity("BookList.Model.Book_Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId");

                    b.ToTable("Book_Author");
                });

            modelBuilder.Entity("BookList.Model.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("PublisherName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("publisher");
                });

            modelBuilder.Entity("BookList.Model.Book", b =>
                {
                    b.HasOne("BookList.Model.Publisher", "publisher")
                        .WithMany()
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("publisher");
                });

            modelBuilder.Entity("BookList.Model.Book_Author", b =>
                {
                    b.HasOne("BookList.Model.Author", "author")
                        .WithMany("book_author")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookList.Model.Book", "book")
                        .WithMany("book_author")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("author");

                    b.Navigation("book");
                });

            modelBuilder.Entity("BookList.Model.Author", b =>
                {
                    b.Navigation("book_author");
                });

            modelBuilder.Entity("BookList.Model.Book", b =>
                {
                    b.Navigation("book_author");
                });
#pragma warning restore 612, 618
        }
    }
}
