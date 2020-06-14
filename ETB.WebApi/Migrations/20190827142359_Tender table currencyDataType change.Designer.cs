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
    [Migration("20190827142359_Tender table currencyDataType change")]
    partial class TendertablecurrencyDataTypechange
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

                    b.Property<string>("DistrictHQ");

                    b.Property<string>("DistrictName");

                    b.Property<string>("State");

                    b.HasKey("Id");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("ETB.Core.Entities.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Capital");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("States");
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

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreationDate");

                    b.Property<int>("Currency");

                    b.Property<string>("Department");

                    b.Property<string>("DescOfWork");

                    b.Property<string>("District");

                    b.Property<DateTime?>("DocumentDownloadEdDate");

                    b.Property<DateTime?>("DocumentDownloadStDate");

                    b.Property<string>("EMD");

                    b.Property<decimal>("EstimatedCost");

                    b.Property<int?>("IsActive");

                    b.Property<DateTime?>("ModificationDate");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Organisation");

                    b.Property<string>("Region");

                    b.Property<string>("TenderDocument");

                    b.Property<string>("TenderRef");

                    b.Property<string>("TenderRefSiteAddress");

                    b.Property<string>("TenderTitle");

                    b.Property<string>("TenderType");

                    b.Property<string>("WorkNo");

                    b.Property<DateTime?>("ePublishDate");

                    b.HasKey("Id");

                    b.ToTable("Tenders");
                });
#pragma warning restore 612, 618
        }
    }
}
