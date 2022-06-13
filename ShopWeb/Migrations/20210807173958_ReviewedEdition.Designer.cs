﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopWeb.Data;

namespace ShopWeb.Migrations
{
    [DbContext(typeof(ShopWebContext))]
    [Migration("20210807173958_ReviewedEdition")]
    partial class ReviewedEdition
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShopWeb.Models.Cart", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTimeBought")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Paid")
                        .HasColumnType("bit");

                    b.Property<string>("ProductID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuantityBought")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("ShopWeb.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photopath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("ProductID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ShopWeb.Models.UserDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Customer");
                });
#pragma warning restore 612, 618
        }
    }
}
