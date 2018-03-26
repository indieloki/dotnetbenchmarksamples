﻿// <auto-generated />
using dotnetbenchmarksamples.Infrastucture.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace dotnetbenchmarksamples.Migrations.MSSQL
{
    [DbContext(typeof(MSSQLContext))]
    [Migration("20180323185914_InitialSchema")]
    partial class InitialSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("dotnetbenchmarksamples.Infrastucture.Model.SampleFirstTablePOCO", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("SampleFirstTablePOCOs");
                });

            modelBuilder.Entity("dotnetbenchmarksamples.Infrastucture.Model.SampleSecondTablePOCO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("SampleFirstTablePOCOId");

                    b.Property<DateTime>("TimeStamp");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("SampleFirstTablePOCOId");

                    b.ToTable("SampleSecondTablePOCOs");
                });

            modelBuilder.Entity("dotnetbenchmarksamples.Infrastucture.Model.SampleSecondTablePOCO", b =>
                {
                    b.HasOne("dotnetbenchmarksamples.Infrastucture.Model.SampleFirstTablePOCO", "SampleFirstTablePOCO")
                        .WithMany()
                        .HasForeignKey("SampleFirstTablePOCOId");
                });
#pragma warning restore 612, 618
        }
    }
}
