﻿// <auto-generated />
using System;
using ETB.WebApi.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ETB.WebApi.Migrations
{
    [DbContext(typeof(ETBContext))]
    [Migration("20190906060820_Adding GenderAttributeToUserDetails")]
    partial class AddingGenderAttributeToUserDetails
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ETB.Core.Entities.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DistrictHQ")
                        .HasMaxLength(100);

                    b.Property<string>("DistrictName")
                        .HasMaxLength(100);

                    b.Property<string>("State")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Districts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DistrictHQ = "Araria",
                            DistrictName = "Araria",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 2,
                            DistrictHQ = "Arwal",
                            DistrictName = "Arwal",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 3,
                            DistrictHQ = "Aurangabad",
                            DistrictName = "Aurangabad",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 4,
                            DistrictHQ = "Banka",
                            DistrictName = "Banka",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 5,
                            DistrictHQ = "Begusarai",
                            DistrictName = "Begusarai",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 6,
                            DistrictHQ = "Bhabhua",
                            DistrictName = "Bhabhua",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 7,
                            DistrictHQ = "Bhagalpur",
                            DistrictName = "Bhagalpur",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 8,
                            DistrictHQ = "Ara",
                            DistrictName = "Bhojpur",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 9,
                            DistrictHQ = "Buxar",
                            DistrictName = "Buxar",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 10,
                            DistrictHQ = "Darbhanga",
                            DistrictName = "Darbhanga",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 11,
                            DistrictHQ = "Motihari",
                            DistrictName = "East Champaran",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 12,
                            DistrictHQ = "Gaya",
                            DistrictName = "Gaya",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 13,
                            DistrictHQ = "Gopalganj",
                            DistrictName = "Gopalganj",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 14,
                            DistrictHQ = "Jamui",
                            DistrictName = "Jamui",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 15,
                            DistrictHQ = "Jehanabad",
                            DistrictName = "Jehanabad",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 16,
                            DistrictHQ = "Katihar",
                            DistrictName = "Katihar",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 17,
                            DistrictHQ = "Khagaria",
                            DistrictName = "Khagaria",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 18,
                            DistrictHQ = "Kishanganj",
                            DistrictName = "Kishanganj",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 19,
                            DistrictHQ = "Lakhisarai",
                            DistrictName = "Lakhisarai",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 20,
                            DistrictHQ = "Madhepura",
                            DistrictName = "Madhepura",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 21,
                            DistrictHQ = "Madhubani",
                            DistrictName = "Madhubani",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 22,
                            DistrictHQ = "Munger",
                            DistrictName = "Munger",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 23,
                            DistrictHQ = "Muzaffarpur ",
                            DistrictName = "Muzaffarpur",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 24,
                            DistrictHQ = "Nalanda ",
                            DistrictName = "Nalanda",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 25,
                            DistrictHQ = "Nawada ",
                            DistrictName = "Nawada",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 26,
                            DistrictHQ = "Patna",
                            DistrictName = "Patna",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 27,
                            DistrictHQ = "Purnea ",
                            DistrictName = "Purnea",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 28,
                            DistrictHQ = "Sasaram",
                            DistrictName = "Rohtas",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 29,
                            DistrictHQ = "Saharsa ",
                            DistrictName = "Saharsa",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 30,
                            DistrictHQ = "Samastipur ",
                            DistrictName = "Samastipur",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 31,
                            DistrictHQ = "Chapra",
                            DistrictName = "Saran",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 32,
                            DistrictHQ = "Sheikhpura",
                            DistrictName = "Sheikhpura",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 33,
                            DistrictHQ = "Sheohar",
                            DistrictName = "Sheohar",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 34,
                            DistrictHQ = "Sitamarhi",
                            DistrictName = "Sitamarhi",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 35,
                            DistrictHQ = "Siwan",
                            DistrictName = "Siwan",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 36,
                            DistrictHQ = "Supaul",
                            DistrictName = "Supaul",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 37,
                            DistrictHQ = "Hajipur",
                            DistrictName = "Vaishali",
                            State = "Bihar"
                        },
                        new
                        {
                            Id = 38,
                            DistrictHQ = "Bettiah",
                            DistrictName = "West Champaran",
                            State = "Bihar"
                        });
                });

            modelBuilder.Entity("ETB.Core.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<int>("Duration");

                    b.Property<int>("IsActive");

                    b.Property<DateTime?>("ModificationDate");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<string>("ServiceRepUrl");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("ETB.Core.Entities.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Capital")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("States");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capital = "Patna",
                            Name = "Bihar"
                        });
                });

            modelBuilder.Entity("ETB.Core.Entities.Tender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BidOpeningDate");

                    b.Property<DateTime>("BidSubmissionEnDate");

                    b.Property<DateTime?>("BidSubmissionStDate");

                    b.Property<decimal>("COT");

                    b.Property<decimal>("CostOfBOQ");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreationDate");

                    b.Property<int>("Currency");

                    b.Property<string>("Department")
                        .HasMaxLength(150);

                    b.Property<string>("DescOfWork");

                    b.Property<string>("District")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("DocumentDownloadEdDate");

                    b.Property<DateTime?>("DocumentDownloadStDate");

                    b.Property<string>("EMD");

                    b.Property<decimal>("EstimatedCost");

                    b.Property<int>("IsActive");

                    b.Property<DateTime?>("ModificationDate");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(100);

                    b.Property<string>("Organisation")
                        .HasMaxLength(150);

                    b.Property<int>("ParentTenderId");

                    b.Property<string>("Region")
                        .HasMaxLength(100);

                    b.Property<string>("TenderDocument")
                        .HasMaxLength(250);

                    b.Property<string>("TenderRef")
                        .HasMaxLength(100);

                    b.Property<string>("TenderRefSiteAddress")
                        .HasMaxLength(250);

                    b.Property<string>("TenderTitle")
                        .HasMaxLength(150);

                    b.Property<string>("TenderType");

                    b.Property<string>("WorkNo")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("ePublishDate");

                    b.HasKey("Id");

                    b.ToTable("Tenders");
                });

            modelBuilder.Entity("ETB.Core.Entities.UserDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(150);

                    b.Property<int>("Age");

                    b.Property<string>("City")
                        .HasMaxLength(75);

                    b.Property<string>("ContactNo1")
                        .HasMaxLength(20);

                    b.Property<string>("ContactNo2Mobile")
                        .HasMaxLength(20);

                    b.Property<string>("ContactNo3Mobile")
                        .HasMaxLength(20);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime?>("DOB");

                    b.Property<int?>("DistrictId");

                    b.Property<string>("Email1")
                        .HasMaxLength(100);

                    b.Property<string>("Email2Optinal")
                        .HasMaxLength(100);

                    b.Property<string>("FName")
                        .HasMaxLength(50);

                    b.Property<int>("Gender");

                    b.Property<int>("IsActive");

                    b.Property<int>("IsDetailUpdated");

                    b.Property<string>("LName")
                        .HasMaxLength(50);

                    b.Property<string>("MName")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("ModificationDate");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(100);

                    b.Property<string>("Nationality")
                        .HasMaxLength(25);

                    b.Property<string>("Organisation")
                        .HasMaxLength(100);

                    b.Property<string>("PhotoUrl")
                        .HasMaxLength(255);

                    b.Property<string>("Pin");

                    b.Property<string>("Salutation")
                        .HasMaxLength(10);

                    b.Property<string>("Title")
                        .HasMaxLength(50);

                    b.Property<int?>("UserInfoId");

                    b.Property<int>("WantEmailNotfi");

                    b.Property<int>("WantSMSNotfi");

                    b.Property<int>("WantWhatsUpNotfi");

                    b.Property<string>("WebUrl")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.HasIndex("UserInfoId");

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("ETB.Core.Entities.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Allow");

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime?>("ModificationDate");

                    b.Property<string>("Pass")
                        .HasMaxLength(255);

                    b.Property<string>("UserId")
                        .HasMaxLength(100);

                    b.Property<int>("UserRole");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("UserInfos");
                });

            modelBuilder.Entity("ETB.Core.Entities.UserSignInLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("SignInTime");

                    b.Property<int>("SignInType");

                    b.Property<int?>("UserInfoId");

                    b.HasKey("Id");

                    b.HasIndex("UserInfoId");

                    b.ToTable("UserSignInLogs");
                });

            modelBuilder.Entity("ETB.Core.Entities.UserSubscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("ExtendedEndDate");

                    b.Property<int>("IsActive");

                    b.Property<bool>("IsPaid");

                    b.Property<DateTime?>("ModificationDate");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(100);

                    b.Property<int>("PayingMethod");

                    b.Property<int?>("ServiceId");

                    b.Property<DateTime>("StartDate");

                    b.Property<int?>("UserDetailId");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.HasIndex("UserDetailId");

                    b.ToTable("UserSubscriptions");
                });

            modelBuilder.Entity("ETB.Core.Entities.UserDetail", b =>
                {
                    b.HasOne("ETB.Core.Entities.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictId");

                    b.HasOne("ETB.Core.Entities.UserInfo", "UserInfo")
                        .WithMany()
                        .HasForeignKey("UserInfoId");
                });

            modelBuilder.Entity("ETB.Core.Entities.UserSignInLog", b =>
                {
                    b.HasOne("ETB.Core.Entities.UserInfo", "UserInfo")
                        .WithMany()
                        .HasForeignKey("UserInfoId");
                });

            modelBuilder.Entity("ETB.Core.Entities.UserSubscription", b =>
                {
                    b.HasOne("ETB.Core.Entities.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId");

                    b.HasOne("ETB.Core.Entities.UserDetail", "UserDetail")
                        .WithMany()
                        .HasForeignKey("UserDetailId");
                });
#pragma warning restore 612, 618
        }
    }
}
