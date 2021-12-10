﻿// <auto-generated />
using System;
using FirstWeblog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FirstWeblog.Migrations
{
    [DbContext(typeof(WeblogContext))]
    partial class WeblogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("FirstWeblog.Models.Log", b =>
                {
                    b.Property<int>("LogID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MemberID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LogID");

                    b.HasIndex("MemberID");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("FirstWeblog.Models.Member", b =>
                {
                    b.Property<int>("MemberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Family")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MemberID");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("FirstWeblog.Models.Log", b =>
                {
                    b.HasOne("FirstWeblog.Models.Member", "Member")
                        .WithMany("Logs")
                        .HasForeignKey("MemberID");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("FirstWeblog.Models.Member", b =>
                {
                    b.Navigation("Logs");
                });
#pragma warning restore 612, 618
        }
    }
}
