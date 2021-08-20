﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ViclesStatus.Models.DBContext;

namespace ViclesStatus.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210816194923_ititCreate")]
    partial class ititCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ViclesStatus.Models.Entities.Customer", b =>
                {
                    b.Property<int>("Customer_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Customer_ID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ViclesStatus.Models.Entities.Vehicle", b =>
                {
                    b.Property<int>("Vehicle_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Customer_ID")
                        .HasColumnType("int");

                    b.Property<string>("RegNr")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Vehicle_ID");

                    b.HasIndex("Customer_ID");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("ViclesStatus.Models.Entities.Vehicle", b =>
                {
                    b.HasOne("ViclesStatus.Models.Entities.Customer", "Customer")
                        .WithMany("Vehicles")
                        .HasForeignKey("Customer_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ViclesStatus.Models.Entities.Customer", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}