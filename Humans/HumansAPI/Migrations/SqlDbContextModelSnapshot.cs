﻿// <auto-generated />
using System;
using HumansAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HumansAPI.Migrations
{
    [DbContext(typeof(SqlDbContext))]
    partial class SqlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HumansAPI.Models.Domain.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("City");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Tbilisi"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Batumi"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Rustavi"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Zugdidi"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Qutaisi"
                        });
                });

            modelBuilder.Entity("HumansAPI.Models.Domain.Human", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Gender")
                        .HasColumnType("tinyint");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Humans");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 2,
                            DateOfBirth = new DateTime(1998, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Temur",
                            Gender = (byte)0,
                            LastName = "Mikava",
                            PersonalNumber = "48001233222",
                            PhotoPath = "adlkfjakdlsf"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            DateOfBirth = new DateTime(1997, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Giorgi",
                            Gender = (byte)0,
                            LastName = "Giorgadze",
                            PersonalNumber = "48001231122",
                            PhotoPath = "sdhfkjhdskjf"
                        },
                        new
                        {
                            Id = 3,
                            CityId = 3,
                            DateOfBirth = new DateTime(2000, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Natia",
                            Gender = (byte)1,
                            LastName = "Natidze",
                            PersonalNumber = "48341233222",
                            PhotoPath = "akjsdh"
                        },
                        new
                        {
                            Id = 4,
                            CityId = 5,
                            DateOfBirth = new DateTime(2002, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Irakli",
                            Gender = (byte)0,
                            LastName = "Ikashvili",
                            PersonalNumber = "48005433222",
                            PhotoPath = "askdjhfdjkf"
                        },
                        new
                        {
                            Id = 5,
                            CityId = 4,
                            DateOfBirth = new DateTime(2004, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Nata",
                            Gender = (byte)1,
                            LastName = "Natashvili",
                            PersonalNumber = "48001267222",
                            PhotoPath = "asdfdfd"
                        },
                        new
                        {
                            Id = 6,
                            CityId = 1,
                            DateOfBirth = new DateTime(1970, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Tika",
                            Gender = (byte)1,
                            LastName = "Tikashvili",
                            PersonalNumber = "48871233222",
                            PhotoPath = "asdfsdf"
                        },
                        new
                        {
                            Id = 7,
                            CityId = 2,
                            DateOfBirth = new DateTime(2001, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Lasha",
                            Gender = (byte)0,
                            LastName = "Lashqarava",
                            PersonalNumber = "48001237622",
                            PhotoPath = "adlkfjjkhakdlsf"
                        },
                        new
                        {
                            Id = 8,
                            CityId = 3,
                            DateOfBirth = new DateTime(1990, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Tazo",
                            Gender = (byte)0,
                            LastName = "Tasidze",
                            PersonalNumber = "48001393222",
                            PhotoPath = "asdfd"
                        },
                        new
                        {
                            Id = 9,
                            CityId = 4,
                            DateOfBirth = new DateTime(1995, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Sandro",
                            Gender = (byte)0,
                            LastName = "Sandroshvili",
                            PersonalNumber = "48001233243",
                            PhotoPath = "adfe3"
                        },
                        new
                        {
                            Id = 10,
                            CityId = 4,
                            DateOfBirth = new DateTime(1999, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Salome",
                            Gender = (byte)1,
                            LastName = "Saloshvili",
                            PersonalNumber = "48763233222",
                            PhotoPath = "adsfdfhdjfh"
                        });
                });

            modelBuilder.Entity("HumansAPI.Models.Domain.HumanConnection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FirstHumanId")
                        .HasColumnType("int");

                    b.Property<int>("SecondHumanId")
                        .HasColumnType("int");

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("FirstHumanId");

                    b.HasIndex("SecondHumanId");

                    b.ToTable("HumanConnection");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstHumanId = 2,
                            SecondHumanId = 4,
                            Type = (byte)1
                        },
                        new
                        {
                            Id = 2,
                            FirstHumanId = 1,
                            SecondHumanId = 3,
                            Type = (byte)2
                        },
                        new
                        {
                            Id = 3,
                            FirstHumanId = 3,
                            SecondHumanId = 5,
                            Type = (byte)1
                        },
                        new
                        {
                            Id = 4,
                            FirstHumanId = 8,
                            SecondHumanId = 9,
                            Type = (byte)3
                        },
                        new
                        {
                            Id = 5,
                            FirstHumanId = 7,
                            SecondHumanId = 1,
                            Type = (byte)0
                        },
                        new
                        {
                            Id = 6,
                            FirstHumanId = 4,
                            SecondHumanId = 3,
                            Type = (byte)2
                        },
                        new
                        {
                            Id = 7,
                            FirstHumanId = 9,
                            SecondHumanId = 4,
                            Type = (byte)3
                        },
                        new
                        {
                            Id = 8,
                            FirstHumanId = 2,
                            SecondHumanId = 1,
                            Type = (byte)2
                        },
                        new
                        {
                            Id = 9,
                            FirstHumanId = 7,
                            SecondHumanId = 4,
                            Type = (byte)1
                        },
                        new
                        {
                            Id = 10,
                            FirstHumanId = 8,
                            SecondHumanId = 10,
                            Type = (byte)1
                        });
                });

            modelBuilder.Entity("HumansAPI.Models.Domain.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("HumanId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("HumanId");

                    b.ToTable("Phone");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HumanId = 2,
                            PhoneNumber = "344433334",
                            Type = (byte)1
                        },
                        new
                        {
                            Id = 2,
                            HumanId = 1,
                            PhoneNumber = "4555555",
                            Type = (byte)2
                        },
                        new
                        {
                            Id = 3,
                            HumanId = 8,
                            PhoneNumber = "6476467",
                            Type = (byte)1
                        },
                        new
                        {
                            Id = 4,
                            HumanId = 7,
                            PhoneNumber = "34564356",
                            Type = (byte)0
                        },
                        new
                        {
                            Id = 5,
                            HumanId = 2,
                            PhoneNumber = "345746756",
                            Type = (byte)0
                        },
                        new
                        {
                            Id = 6,
                            HumanId = 6,
                            PhoneNumber = "34574656",
                            Type = (byte)2
                        },
                        new
                        {
                            Id = 7,
                            HumanId = 10,
                            PhoneNumber = "23455",
                            Type = (byte)1
                        },
                        new
                        {
                            Id = 8,
                            HumanId = 3,
                            PhoneNumber = "34565",
                            Type = (byte)0
                        },
                        new
                        {
                            Id = 9,
                            HumanId = 4,
                            PhoneNumber = "34565",
                            Type = (byte)2
                        },
                        new
                        {
                            Id = 10,
                            HumanId = 5,
                            PhoneNumber = "345432",
                            Type = (byte)0
                        });
                });

            modelBuilder.Entity("HumansAPI.Models.Domain.Human", b =>
                {
                    b.HasOne("HumansAPI.Models.Domain.City", "City")
                        .WithMany("Humans")
                        .HasForeignKey("CityId");

                    b.Navigation("City");
                });

            modelBuilder.Entity("HumansAPI.Models.Domain.HumanConnection", b =>
                {
                    b.HasOne("HumansAPI.Models.Domain.Human", "FirstHuman")
                        .WithMany("Connections")
                        .HasForeignKey("FirstHumanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HumansAPI.Models.Domain.Human", "SecondHuman")
                        .WithMany()
                        .HasForeignKey("SecondHumanId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("FirstHuman");

                    b.Navigation("SecondHuman");
                });

            modelBuilder.Entity("HumansAPI.Models.Domain.Phone", b =>
                {
                    b.HasOne("HumansAPI.Models.Domain.Human", "Human")
                        .WithMany("Phones")
                        .HasForeignKey("HumanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Human");
                });

            modelBuilder.Entity("HumansAPI.Models.Domain.City", b =>
                {
                    b.Navigation("Humans");
                });

            modelBuilder.Entity("HumansAPI.Models.Domain.Human", b =>
                {
                    b.Navigation("Connections");

                    b.Navigation("Phones");
                });
#pragma warning restore 612, 618
        }
    }
}
