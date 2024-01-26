﻿// <auto-generated />
using System;
using EmaAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmaAPI.Migrations
{
    [DbContext(typeof(EmaDbContext))]
    [Migration("20240123053003_onemigrationss")]
    partial class onemigrationss
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmaAPI.Models.Company", b =>
                {
                    b.Property<int?>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("RecordId"));

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("Varchar");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("Varchar");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("Varchar");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("TaxNo")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar");

                    b.Property<string>("TaxOffice")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Website")
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.HasKey("RecordId");

                    b.HasIndex("UserId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("EmaAPI.Models.Customer", b =>
                {
                    b.Property<int?>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("RecordId"));

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("Varchar");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("Varchar");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("Varchar");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("Varchar");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RecordId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("UserId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("EmaAPI.Models.Item", b =>
                {
                    b.Property<int?>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("RecordId"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("CreatedDatetime")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<decimal?>("DiscountRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal?>("PurchasePrice")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("SalesPrice")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("StockQuantity")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDatetime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<decimal?>("VatRate")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("RecordId");

                    b.HasIndex("UserId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("EmaAPI.Models.User", b =>
                {
                    b.Property<int?>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("RecordId"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDatetime")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("RecordId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Invoice", b =>
                {
                    b.Property<int?>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("RecordId"));

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InvoiceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("OrderNumber")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<decimal?>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RecordId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("UserId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("InvoiceLine", b =>
                {
                    b.Property<int?>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("RecordId"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<decimal?>("DiscountRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<decimal?>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<decimal?>("VatRate")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("RecordId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ItemId");

                    b.HasIndex("UserId");

                    b.ToTable("InvoiceLines");
                });

            modelBuilder.Entity("EmaAPI.Models.Company", b =>
                {
                    b.HasOne("EmaAPI.Models.User", "User")
                        .WithMany("Company")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EmaAPI.Models.Customer", b =>
                {
                    b.HasOne("EmaAPI.Models.Company", "Company")
                        .WithMany("Customer")
                        .HasForeignKey("CompanyId");

                    b.HasOne("EmaAPI.Models.User", "User")
                        .WithMany("Customer")
                        .HasForeignKey("UserId");

                    b.Navigation("Company");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EmaAPI.Models.Item", b =>
                {
                    b.HasOne("EmaAPI.Models.User", "User")
                        .WithMany("Item")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Invoice", b =>
                {
                    b.HasOne("EmaAPI.Models.Company", "Company")
                        .WithMany("Invoice")
                        .HasForeignKey("CompanyId");

                    b.HasOne("EmaAPI.Models.Customer", "Customer")
                        .WithMany("Invoice")
                        .HasForeignKey("CustomerId");

                    b.HasOne("EmaAPI.Models.User", "User")
                        .WithMany("Invoice")
                        .HasForeignKey("UserId");

                    b.Navigation("Company");

                    b.Navigation("Customer");

                    b.Navigation("User");
                });

            modelBuilder.Entity("InvoiceLine", b =>
                {
                    b.HasOne("Invoice", "Invoice")
                        .WithMany("InvoiceLines")
                        .HasForeignKey("InvoiceId");

                    b.HasOne("EmaAPI.Models.Item", "Item")
                        .WithMany("InvoiceLine")
                        .HasForeignKey("ItemId");

                    b.HasOne("EmaAPI.Models.User", "User")
                        .WithMany("InvoiceLine")
                        .HasForeignKey("UserId");

                    b.Navigation("Invoice");

                    b.Navigation("Item");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EmaAPI.Models.Company", b =>
                {
                    b.Navigation("Customer");

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("EmaAPI.Models.Customer", b =>
                {
                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("EmaAPI.Models.Item", b =>
                {
                    b.Navigation("InvoiceLine");
                });

            modelBuilder.Entity("EmaAPI.Models.User", b =>
                {
                    b.Navigation("Company");

                    b.Navigation("Customer");

                    b.Navigation("Invoice");

                    b.Navigation("InvoiceLine");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Invoice", b =>
                {
                    b.Navigation("InvoiceLines");
                });
#pragma warning restore 612, 618
        }
    }
}
