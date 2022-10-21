﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Diploma.DB;

#nullable disable

namespace Diploma.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Module6HW7.Models.Catalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RouteName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CatalogItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImgUrl = "https://content1.rozetka.com.ua/goods/images/big_tile/267792323.jpg",
                            RouteName = "teapots",
                            Title = "Teapots"
                        },
                        new
                        {
                            Id = 2,
                            ImgUrl = "https://content.rozetka.com.ua/goods/images/big_tile/160433459.jpg",
                            RouteName = "coffee-machines",
                            Title = "Coffee machines"
                        });
                });

            modelBuilder.Entity("Module6HW7.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalSum")
                        .HasColumnType("float");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrderStatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Module6HW7.Models.OrderProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("Module6HW7.Models.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrderStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Awaiting confirmation"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Accepted"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Packing"
                        },
                        new
                        {
                            Id = 4,
                            Title = "In delivery"
                        },
                        new
                        {
                            Id = 5,
                            Title = "Deliveried"
                        },
                        new
                        {
                            Id = 6,
                            Title = "Declined"
                        });
                });

            modelBuilder.Entity("Module6HW7.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Capacity")
                        .HasColumnType("float");

                    b.Property<int>("CatalogId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManufacturerCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WarrantyInMonths")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CatalogId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f07aaaf1-9034-44ad-85de-57c60b9fd30e"),
                            Capacity = 1.7,
                            CatalogId = 1,
                            Description = "Safety in 3 dimensions: automatic shutdown, protection against leakage and overheating, LED indication.",
                            ImgUrl = "https://content.rozetka.com.ua/goods/images/big_tile/10648417.jpg",
                            ManufacturerCountry = "China",
                            Price = 1199.0,
                            Quantity = 8,
                            Title = "Teapot BOSCH TWK3A013",
                            WarrantyInMonths = 12
                        },
                        new
                        {
                            Id = new Guid("91579720-12b6-44a8-86c6-8ddc7ab6846b"),
                            Capacity = 1.7,
                            CatalogId = 1,
                            Description = "Inspired by traditional British ceramics, the Loft teapot's stunning fluted lines are elegantly paired with modern chrome accents for a timeless design that looks great in any kitchen.",
                            ImgUrl = "https://content1.rozetka.com.ua/goods/images/big_tile/64732971.jpg",
                            ManufacturerCountry = "China",
                            Price = 1299.0,
                            Quantity = 12,
                            Title = "Teapot TEFAL LOFT KO250830",
                            WarrantyInMonths = 24
                        },
                        new
                        {
                            Id = new Guid("f15c03c0-01f9-44e1-9f14-fdff72ffcf7a"),
                            Capacity = 1.7,
                            CatalogId = 1,
                            Description = "Safety in 3 dimensions: automatic shutdown, protection against leakage and overheating, LED indication.",
                            ImgUrl = "https://content1.rozetka.com.ua/goods/images/big_tile/19966325.jpg",
                            ManufacturerCountry = "China",
                            Price = 2299.0,
                            Quantity = 7,
                            Title = "Teapot BOSCH TWK3P423",
                            WarrantyInMonths = 24
                        },
                        new
                        {
                            Id = new Guid("0d542238-0835-4595-a677-c361df0f12f2"),
                            Capacity = 1.7,
                            CatalogId = 1,
                            Description = "Prepare hot drinks in no time with 2200W of power",
                            ImgUrl = "https://content1.rozetka.com.ua/goods/images/big_tile/267792323.jpg",
                            ManufacturerCountry = "China",
                            Price = 2349.0,
                            Quantity = 13,
                            Title = "Teapot Philips Eco HD9365/10",
                            WarrantyInMonths = 24
                        },
                        new
                        {
                            Id = new Guid("4d0ba9ef-5a12-4aa2-8fc1-2faa82120b6b"),
                            Capacity = 1.7,
                            CatalogId = 1,
                            Description = "With keep warm function; fast, safe boiling; easy to fill, use and clean",
                            ImgUrl = "https://content2.rozetka.com.ua/goods/images/big_tile/274310222.jpg",
                            ManufacturerCountry = "China",
                            Price = 2399.0,
                            Quantity = 7,
                            Title = "Teapot Philips Viva Collection HD9355/92",
                            WarrantyInMonths = 24
                        },
                        new
                        {
                            Id = new Guid("2afd3692-16bb-4b97-9284-7596d9c1d938"),
                            Capacity = 1.5,
                            CatalogId = 1,
                            Description = "With the AENO EK4 electric kettle, you can boil water in just 5 minutes and have time to prepare tea or coffee for the arrival of guests.",
                            ImgUrl = "https://content2.rozetka.com.ua/goods/images/big_tile/248635439.jpg",
                            ManufacturerCountry = "China",
                            Price = 1099.0,
                            Quantity = 9,
                            Title = "Teapot AENO EK4",
                            WarrantyInMonths = 24
                        },
                        new
                        {
                            Id = new Guid("9db4706e-b92e-448e-919c-c39568457d21"),
                            Capacity = 1.5,
                            CatalogId = 1,
                            Description = "Good teapot",
                            ImgUrl = "https://content.rozetka.com.ua/goods/images/big_tile/14708920.jpg",
                            ManufacturerCountry = "China",
                            Price = 1399.0,
                            Quantity = 9,
                            Title = "Teapot 7",
                            WarrantyInMonths = 12
                        },
                        new
                        {
                            Id = new Guid("9d4c9e20-7d6c-4002-8401-8055cdd439ed"),
                            Capacity = 1.5,
                            CatalogId = 1,
                            Description = "Good teapot",
                            ImgUrl = "https://content1.rozetka.com.ua/goods/images/big_tile/283417981.png",
                            ManufacturerCountry = "China",
                            Price = 1469.0,
                            Quantity = 9,
                            Title = "Teapot 8",
                            WarrantyInMonths = 12
                        },
                        new
                        {
                            Id = new Guid("5be8eb41-df74-4c62-9468-d9dc3697ec5c"),
                            Capacity = 1.5,
                            CatalogId = 1,
                            Description = "Good teapot",
                            ImgUrl = "https://content1.rozetka.com.ua/goods/images/big_tile/10626237.jpg",
                            ManufacturerCountry = "China",
                            Price = 1599.0,
                            Quantity = 9,
                            Title = "Teapot 9",
                            WarrantyInMonths = 12
                        },
                        new
                        {
                            Id = new Guid("67f3170c-c25e-4ef4-9d26-68db38d98f10"),
                            Capacity = 1.5,
                            CatalogId = 1,
                            Description = "Good teapot",
                            ImgUrl = "https://content1.rozetka.com.ua/goods/images/big_tile/81865256.jpg",
                            ManufacturerCountry = "China",
                            Price = 2399.0,
                            Quantity = 9,
                            Title = "Teapot 10",
                            WarrantyInMonths = 12
                        },
                        new
                        {
                            Id = new Guid("9e25fb7a-9f90-466a-b515-422023d11107"),
                            Capacity = 1.5,
                            CatalogId = 1,
                            Description = "Good teapot",
                            ImgUrl = "https://content.rozetka.com.ua/goods/images/big_tile/142971427.jpg",
                            ManufacturerCountry = "China",
                            Price = 2899.0,
                            Quantity = 9,
                            Title = "Teapot 11",
                            WarrantyInMonths = 12
                        },
                        new
                        {
                            Id = new Guid("c52e0f08-dc5d-4652-9e78-ee08659f78ca"),
                            Capacity = 1.5,
                            CatalogId = 1,
                            Description = "Good teapot",
                            ImgUrl = "https://content.rozetka.com.ua/goods/images/big_tile/163131692.jpg",
                            ManufacturerCountry = "China",
                            Price = 2229.0,
                            Quantity = 9,
                            Title = "Teapot 12",
                            WarrantyInMonths = 12
                        },
                        new
                        {
                            Id = new Guid("5e99667f-d035-4f0b-bef8-e97d86bc454f"),
                            Capacity = 12.0,
                            CatalogId = 2,
                            Description = "Good teapot",
                            ImgUrl = "https://content.rozetka.com.ua/goods/images/big_tile/160433459.jpg",
                            ManufacturerCountry = "China",
                            Price = 2229.0,
                            Quantity = 9,
                            Title = "Coffee machine 1",
                            WarrantyInMonths = 12
                        },
                        new
                        {
                            Id = new Guid("ff989a51-3e96-4afa-b57f-f1e907c0a9d9"),
                            Capacity = 12.0,
                            CatalogId = 2,
                            Description = "Good teapot",
                            ImgUrl = "https://content.rozetka.com.ua/goods/images/big_tile/15790055.jpg",
                            ManufacturerCountry = "China",
                            Price = 1579.0,
                            Quantity = 3,
                            Title = "Coffee machine 2",
                            WarrantyInMonths = 24
                        },
                        new
                        {
                            Id = new Guid("06a77f8c-bd27-4c5c-acd9-3bfc94e23c50"),
                            Capacity = 12.0,
                            CatalogId = 2,
                            Description = "Good teapot",
                            ImgUrl = "https://content2.rozetka.com.ua/goods/images/big_tile/29270053.jpg",
                            ManufacturerCountry = "China",
                            Price = 2379.0,
                            Quantity = 5,
                            Title = "Coffee machine 3",
                            WarrantyInMonths = 18
                        },
                        new
                        {
                            Id = new Guid("2a265306-3480-443f-b0f3-e4f8a748f6ca"),
                            Capacity = 12.0,
                            CatalogId = 2,
                            Description = "Good teapot",
                            ImgUrl = "https://content2.rozetka.com.ua/goods/images/big_tile/160392353.jpg",
                            ManufacturerCountry = "China",
                            Price = 1899.0,
                            Quantity = 17,
                            Title = "Coffee machine 4",
                            WarrantyInMonths = 12
                        },
                        new
                        {
                            Id = new Guid("c3939574-9260-411d-94ae-6d227845f43f"),
                            Capacity = 12.0,
                            CatalogId = 2,
                            Description = "Good teapot",
                            ImgUrl = "https://content.rozetka.com.ua/goods/images/big_tile/76717007.jpg",
                            ManufacturerCountry = "China",
                            Price = 1989.0,
                            Quantity = 3,
                            Title = "Coffee machine 5",
                            WarrantyInMonths = 6
                        },
                        new
                        {
                            Id = new Guid("60fb3b2a-49ed-4cff-b45b-fc20f3d8fc3e"),
                            Capacity = 12.0,
                            CatalogId = 2,
                            Description = "Good teapot",
                            ImgUrl = "https://content.rozetka.com.ua/goods/images/big_tile/45610581.jpg",
                            ManufacturerCountry = "China",
                            Price = 2359.0,
                            Quantity = 9,
                            Title = "Coffee machine 6",
                            WarrantyInMonths = 30
                        },
                        new
                        {
                            Id = new Guid("0248fe94-662e-419d-b069-7631c0938fba"),
                            Capacity = 12.0,
                            CatalogId = 2,
                            Description = "Good teapot",
                            ImgUrl = "https://content1.rozetka.com.ua/goods/images/big_tile/160843463.jpg",
                            ManufacturerCountry = "China",
                            Price = 3599.0,
                            Quantity = 10,
                            Title = "Coffee machine 7",
                            WarrantyInMonths = 24
                        },
                        new
                        {
                            Id = new Guid("c104f203-0d63-42b2-8601-dccbcde2ba74"),
                            Capacity = 12.0,
                            CatalogId = 2,
                            Description = "Good teapot",
                            ImgUrl = "https://content.rozetka.com.ua/goods/images/big_tile/167686386.jpg",
                            ManufacturerCountry = "China",
                            Price = 4179.0,
                            Quantity = 8,
                            Title = "Coffee machine 8",
                            WarrantyInMonths = 6
                        },
                        new
                        {
                            Id = new Guid("42d8e4ad-c170-4f6c-921e-57c489a3e3d1"),
                            Capacity = 12.0,
                            CatalogId = 2,
                            Description = "Good teapot",
                            ImgUrl = "https://content.rozetka.com.ua/goods/images/big_tile/13821301.jpg",
                            ManufacturerCountry = "China",
                            Price = 1789.0,
                            Quantity = 5,
                            Title = "Coffee machine 9",
                            WarrantyInMonths = 24
                        },
                        new
                        {
                            Id = new Guid("d00e8174-be1b-43c8-b5a1-78a96f13e1d6"),
                            Capacity = 12.0,
                            CatalogId = 2,
                            Description = "Good teapot",
                            ImgUrl = "https://content2.rozetka.com.ua/goods/images/big_tile/11675316.jpg",
                            ManufacturerCountry = "China",
                            Price = 6789.0,
                            Quantity = 7,
                            Title = "Coffee machine 10",
                            WarrantyInMonths = 12
                        });
                });

            modelBuilder.Entity("Module6HW7.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Client"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Admin"
                        });
                });

            modelBuilder.Entity("Module6HW7.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Module6HW7.Models.Order", b =>
                {
                    b.HasOne("Module6HW7.Models.OrderStatus", "OrderStatus")
                        .WithMany()
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Module6HW7.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderStatus");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Module6HW7.Models.OrderProduct", b =>
                {
                    b.HasOne("Module6HW7.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Module6HW7.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Module6HW7.Models.Product", b =>
                {
                    b.HasOne("Module6HW7.Models.Catalog", "Catalog")
                        .WithMany()
                        .HasForeignKey("CatalogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Catalog");
                });

            modelBuilder.Entity("Module6HW7.Models.User", b =>
                {
                    b.HasOne("Module6HW7.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
