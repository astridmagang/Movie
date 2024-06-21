﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zeta.Movie.Infrastructure.Persistence;

#nullable disable

namespace Zeta.Movie.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220714063255_ApplicationDbContext_001_InitialSchema")]
    partial class ApplicationDbContext_001_InitialSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Zeta.Movie.Domain.Entities.ToDoGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("Modified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("ToDoGroups", "Movie");
                });

            modelBuilder.Entity("Zeta.Movie.Domain.Entities.ToDoItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("Modified")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("PriorityLevel")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("ToDoGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ToDoGroupId");

                    b.ToTable("ToDoItems", "Movie");
                });

            modelBuilder.Entity("Zeta.Movie.Domain.Entities.ToDoItem", b =>
                {
                    b.HasOne("Zeta.Movie.Domain.Entities.ToDoGroup", "ToDoGroup")
                        .WithMany("ToDoItems")
                        .HasForeignKey("ToDoGroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ToDoGroup");
                });

            modelBuilder.Entity("Zeta.Movie.Domain.Entities.ToDoGroup", b =>
                {
                    b.Navigation("ToDoItems");
                });
#pragma warning restore 612, 618
        }
    }
}
