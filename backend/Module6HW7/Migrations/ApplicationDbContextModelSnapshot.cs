﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Module6HW7.DB;

namespace Module6HW7.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Module6HW7.Models.Catalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                            Id = new Guid("3b7daba0-c1bb-4c7a-bf8b-ad0111c02f25"),
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
                            Id = new Guid("3b77a34c-ab3a-4af1-87f1-ebc82b7e6720"),
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
                            Id = new Guid("3771da17-3589-477d-bb44-c45a2b318142"),
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
                            Id = new Guid("77d96428-f409-4946-887d-dcb64cb6a1f7"),
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
                            Id = new Guid("82ebd8a1-5ac3-4a5a-9b56-8152568c23e2"),
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
                            Id = new Guid("eef985a1-fc8c-4133-b62b-137d071f263f"),
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
                            Id = new Guid("b4d33b5c-0d83-42e4-a5df-1d70f11d15a7"),
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
                            Id = new Guid("275f2900-9149-49f3-9df8-f986a16fda46"),
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
                            Id = new Guid("9e3b080d-9c82-4da8-a80e-24e7815701b6"),
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
                            Id = new Guid("64e4e7a5-54f1-4d84-8573-8bf2474ccfd1"),
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
                            Id = new Guid("4602ed5e-80e0-4a6a-ba6b-2c11f7f7c45c"),
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
                            Id = new Guid("de581a5b-949a-49eb-9a43-262223877d9a"),
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
                            Id = new Guid("0d370839-1c27-420a-a0dc-acc41c83d70e"),
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
                            Id = new Guid("03dab1ef-89c9-42d4-bb86-d454dcfc0091"),
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
                            Id = new Guid("320a3fee-513d-4cb2-82d2-94ad9994d572"),
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
                            Id = new Guid("06b0ba5a-56b7-47dc-af62-16eb11d68dea"),
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
                            Id = new Guid("0c865983-1b3f-4f1c-b0c0-a9e5b82c7b2f"),
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
                            Id = new Guid("2fc6639a-b7c7-42e5-b88b-d19a95b5a745"),
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
                            Id = new Guid("febc511b-d5d6-472e-a072-3bdf02374aa9"),
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
                            Id = new Guid("f6da9012-e106-40b5-a7ad-a711b5e770b6"),
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
                            Id = new Guid("112fe116-9364-45eb-8cb2-b7f3c4b59a35"),
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
                            Id = new Guid("aa4115ff-61c4-43a7-802a-33b093fbdbb1"),
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

            modelBuilder.Entity("Module6HW7.Models.Product", b =>
                {
                    b.HasOne("Module6HW7.Models.Catalog", "Catalog")
                        .WithMany("Products")
                        .HasForeignKey("CatalogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Catalog");
                });

            modelBuilder.Entity("Module6HW7.Models.Catalog", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
