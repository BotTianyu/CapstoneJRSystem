﻿// <auto-generated />
using System;
using JRSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JRSystem.Migrations
{
    [DbContext(typeof(ReferralDBContext))]
    [Migration("20230614025649_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JRSystem.Models.Referral", b =>
                {
                    b.Property<string>("ReferralId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReferralDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReferralName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("deadline")
                        .HasColumnType("datetime2");

                    b.HasKey("ReferralId");

                    b.ToTable("ReferralSets");
                });
#pragma warning restore 612, 618
        }
    }
}
