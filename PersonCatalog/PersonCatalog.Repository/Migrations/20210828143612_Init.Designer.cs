﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonCatalog.Repository.Context;

namespace PersonCatalog.Repository.Migrations
{
    [DbContext(typeof(PersonDbContext))]
    [Migration("20210828143612_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PersonCatalog.Domain.Domains.City", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "tbilisi"
                        },
                        new
                        {
                            ID = 2,
                            Name = "batumi"
                        });
                });

            modelBuilder.Entity("PersonCatalog.Domain.Domains.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("ImageFilename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PersonalNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("CityID");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            BirthDate = new DateTime(1998, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CityID = 1,
                            Gender = 1,
                            Name = "rati",
                            PersonalNumber = "00000000000",
                            Surname = "laitadze"
                        },
                        new
                        {
                            ID = 2,
                            BirthDate = new DateTime(1992, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CityID = 1,
                            Gender = 1,
                            Name = "levani",
                            PersonalNumber = "00008000001",
                            Surname = "laitadze"
                        },
                        new
                        {
                            ID = 3,
                            BirthDate = new DateTime(1970, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CityID = 1,
                            Gender = 1,
                            Name = "vaxo",
                            PersonalNumber = "00000000002",
                            Surname = "laitadze"
                        },
                        new
                        {
                            ID = 4,
                            BirthDate = new DateTime(1970, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CityID = 2,
                            Gender = 2,
                            Name = "nana",
                            PersonalNumber = "00000000003",
                            Surname = "eliava"
                        });
                });

            modelBuilder.Entity("PersonCatalog.Domain.Domains.PhoneNumber", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.Property<int>("phoneNumberType")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PersonID");

                    b.ToTable("PhoneNumbers");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Number = "000000000",
                            PersonID = 1,
                            phoneNumberType = 1
                        },
                        new
                        {
                            ID = 2,
                            Number = "0320000000",
                            PersonID = 1,
                            phoneNumberType = 3
                        },
                        new
                        {
                            ID = 3,
                            Number = "500000000",
                            PersonID = 2,
                            phoneNumberType = 1
                        },
                        new
                        {
                            ID = 4,
                            Number = "500000001",
                            PersonID = 3,
                            phoneNumberType = 1
                        },
                        new
                        {
                            ID = 5,
                            Number = "500000002",
                            PersonID = 4,
                            phoneNumberType = 1
                        },
                        new
                        {
                            ID = 6,
                            Number = "50000003",
                            PersonID = 4,
                            phoneNumberType = 2
                        });
                });

            modelBuilder.Entity("PersonCatalog.Domain.Domains.Relation", b =>
                {
                    b.Property<int>("PersonFromID")
                        .HasColumnType("int");

                    b.Property<int>("PersonToID")
                        .HasColumnType("int");

                    b.Property<int>("RelationType")
                        .HasColumnType("int");

                    b.HasKey("PersonFromID", "PersonToID");

                    b.HasIndex("PersonToID");

                    b.ToTable("Relations");

                    b.HasData(
                        new
                        {
                            PersonFromID = 1,
                            PersonToID = 2,
                            RelationType = 1
                        },
                        new
                        {
                            PersonFromID = 1,
                            PersonToID = 3,
                            RelationType = 1
                        },
                        new
                        {
                            PersonFromID = 1,
                            PersonToID = 4,
                            RelationType = 4
                        },
                        new
                        {
                            PersonFromID = 2,
                            PersonToID = 4,
                            RelationType = 2
                        },
                        new
                        {
                            PersonFromID = 2,
                            PersonToID = 3,
                            RelationType = 4
                        },
                        new
                        {
                            PersonFromID = 3,
                            PersonToID = 4,
                            RelationType = 1
                        });
                });

            modelBuilder.Entity("PersonCatalog.Domain.Domains.Person", b =>
                {
                    b.HasOne("PersonCatalog.Domain.Domains.City", "City")
                        .WithMany("People")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("PersonCatalog.Domain.Domains.PhoneNumber", b =>
                {
                    b.HasOne("PersonCatalog.Domain.Domains.Person", "Person")
                        .WithMany("Phones")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("PersonCatalog.Domain.Domains.Relation", b =>
                {
                    b.HasOne("PersonCatalog.Domain.Domains.Person", "PersonFrom")
                        .WithMany("RelativeTo")
                        .HasForeignKey("PersonFromID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PersonCatalog.Domain.Domains.Person", "PersonTo")
                        .WithMany("RelativeFrom")
                        .HasForeignKey("PersonToID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonFrom");

                    b.Navigation("PersonTo");
                });

            modelBuilder.Entity("PersonCatalog.Domain.Domains.City", b =>
                {
                    b.Navigation("People");
                });

            modelBuilder.Entity("PersonCatalog.Domain.Domains.Person", b =>
                {
                    b.Navigation("Phones");

                    b.Navigation("RelativeFrom");

                    b.Navigation("RelativeTo");
                });
#pragma warning restore 612, 618
        }
    }
}