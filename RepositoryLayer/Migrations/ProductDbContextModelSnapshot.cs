﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepositoryLayer;

namespace RepositoryLayer.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    partial class ProductDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("DomainLayer.AdminProductsOperations.AddProduct", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("model")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Model");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Name");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<string>("productBrand")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Brand");

                    b.Property<string>("productType")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Type");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<int?>("specsid")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("specsid");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("DomainLayer.AdminProductsOperations.Image", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ProductEntityId")
                        .HasColumnType("int");

                    b.Property<string>("imagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("productid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("productid");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("DomainLayer.AdminProductsOperations.MasterData", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<string>("masterData")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("MasterData");

                    b.Property<int?>("parantId")
                        .HasColumnType("int")
                        .HasColumnName("PerantId");

                    b.HasKey("id");

                    b.ToTable("MasterData");
                });

            modelBuilder.Entity("DomainLayer.AdminProductsOperations.Ram", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("Specificationid")
                        .HasColumnType("int");

                    b.Property<string>("ram")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Specificationid");

                    b.ToTable("Ram");
                });

            modelBuilder.Entity("DomainLayer.AdminProductsOperations.Specification", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("camFeatures")
                        .HasColumnType("int");

                    b.Property<string>("core")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("os")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("processor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("simType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Specification");
                });

            modelBuilder.Entity("DomainLayer.AdminProductsOperations.Storage", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("Specificationid")
                        .HasColumnType("int");

                    b.Property<string>("storage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Specificationid");

                    b.ToTable("Storage");
                });

            modelBuilder.Entity("DomainLayer.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DomainLayer.AdminProductsOperations.AddProduct", b =>
                {
                    b.HasOne("DomainLayer.AdminProductsOperations.Specification", "specs")
                        .WithMany()
                        .HasForeignKey("specsid");

                    b.Navigation("specs");
                });

            modelBuilder.Entity("DomainLayer.AdminProductsOperations.Image", b =>
                {
                    b.HasOne("DomainLayer.AdminProductsOperations.AddProduct", "product")
                        .WithMany("images")
                        .HasForeignKey("productid");

                    b.Navigation("product");
                });

            modelBuilder.Entity("DomainLayer.AdminProductsOperations.Ram", b =>
                {
                    b.HasOne("DomainLayer.AdminProductsOperations.Specification", null)
                        .WithMany("rams")
                        .HasForeignKey("Specificationid");
                });

            modelBuilder.Entity("DomainLayer.AdminProductsOperations.Storage", b =>
                {
                    b.HasOne("DomainLayer.AdminProductsOperations.Specification", null)
                        .WithMany("storages")
                        .HasForeignKey("Specificationid");
                });

            modelBuilder.Entity("DomainLayer.AdminProductsOperations.AddProduct", b =>
                {
                    b.Navigation("images");
                });

            modelBuilder.Entity("DomainLayer.AdminProductsOperations.Specification", b =>
                {
                    b.Navigation("rams");

                    b.Navigation("storages");
                });
#pragma warning restore 612, 618
        }
    }
}
