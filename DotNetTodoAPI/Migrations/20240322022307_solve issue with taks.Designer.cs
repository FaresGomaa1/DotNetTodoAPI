﻿// <auto-generated />
using System;
using DotNetTodoAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DotNetTodoAPI.Migrations
{
    [DbContext(typeof(TodoContext))]
    [Migration("20240322022307_solve issue with taks")]
    partial class solveissuewithtaks
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DotNetTodoAPI.Model.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("TodoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TodoId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("DotNetTodoAPI.Model.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DotNetTodoAPI.Model.Tasks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Priority")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TodoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TodoId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("DotNetTodoAPI.Model.Todo", b =>
                {
                    b.Property<int>("TodoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TodoId"));

                    b.Property<string>("TodoStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TodoTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("TodoId");

                    b.ToTable("Todos");
                });

            modelBuilder.Entity("DotNetTodoAPI.Model.TodoCategory", b =>
                {
                    b.Property<int>("TodoId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("TodoId");

                    b.HasIndex("CategoryId");

                    b.ToTable("TodoCategories");
                });

            modelBuilder.Entity("DotNetTodoAPI.Model.Attachment", b =>
                {
                    b.HasOne("DotNetTodoAPI.Model.Todo", null)
                        .WithMany("Attachments")
                        .HasForeignKey("TodoId");
                });

            modelBuilder.Entity("DotNetTodoAPI.Model.Tasks", b =>
                {
                    b.HasOne("DotNetTodoAPI.Model.Todo", "Todo")
                        .WithMany("Tasks")
                        .HasForeignKey("TodoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Todo");
                });

            modelBuilder.Entity("DotNetTodoAPI.Model.TodoCategory", b =>
                {
                    b.HasOne("DotNetTodoAPI.Model.Category", "Category")
                        .WithMany("TodoCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DotNetTodoAPI.Model.Todo", "Todo")
                        .WithMany("TodoCategories")
                        .HasForeignKey("TodoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Todo");
                });

            modelBuilder.Entity("DotNetTodoAPI.Model.Category", b =>
                {
                    b.Navigation("TodoCategories");
                });

            modelBuilder.Entity("DotNetTodoAPI.Model.Todo", b =>
                {
                    b.Navigation("Attachments");

                    b.Navigation("Tasks");

                    b.Navigation("TodoCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
