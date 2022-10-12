using Microsoft.EntityFrameworkCore;
using Module6HW7.Models;

namespace Module6HW7.DB
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Catalog> CatalogItems { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {
            // Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catalog>().HasData(
                new Catalog
                {
                    Id = 1,
                    Title = "Teapots",
                    ImgUrl = "https://content1.rozetka.com.ua/goods/images/big_tile/267792323.jpg",
                    RouteName = "teapots"
                },
                new Catalog
                {
                    Id = 2,
                    Title = "Coffee machines",
                    ImgUrl = "https://content.rozetka.com.ua/goods/images/big_tile/160433459.jpg",
                    RouteName = "coffee-machines"
                });

            modelBuilder.Entity<Product>().HasData(
                new Product 
                { 
                    Title = "Teapot BOSCH TWK3A013", 
                    ImgUrl = "https://content.rozetka.com.ua/goods/images/big_tile/10648417.jpg",
                    Capacity = 1.7,
                    Description = "Safety in 3 dimensions: automatic shutdown, protection against " +
                    "leakage and overheating, LED indication.",
                    ManufacturerCountry = "China",
                    Price = 1199,
                    Quantity = 8,
                    WarrantyInMonths = 12,
                    CatalogId = 1
                },
                new Product
                {
                    Title = "Teapot TEFAL LOFT KO250830",
                    ImgUrl = "https://content1.rozetka.com.ua/goods/images/big_tile/64732971.jpg",
                    Capacity = 1.7,
                    Description = "Inspired by traditional British ceramics, the Loft teapot's stunning " +
                    "fluted lines are elegantly paired with modern chrome accents for a timeless " +
                    "design that looks great in any kitchen.",
                    ManufacturerCountry = "China",
                    Price = 1299,
                    Quantity = 12,
                    WarrantyInMonths = 24,
                    CatalogId = 1
                },
                new Product
                {
                    Title = "Teapot BOSCH TWK3P423",
                    ImgUrl = "https://content1.rozetka.com.ua/goods/images/big_tile/19966325.jpg",
                    Capacity = 1.7,
                    Description = "Safety in 3 dimensions: automatic shutdown, protection against " +
                    "leakage and overheating, LED indication.",
                    ManufacturerCountry = "China",
                    Price = 2299,
                    Quantity = 7,
                    WarrantyInMonths = 24,
                    CatalogId = 1
                },
                new Product
                {
                    Title = "Teapot Philips Eco HD9365/10",
                    ImgUrl = "https://content1.rozetka.com.ua/goods/images/big_tile/267792323.jpg",
                    Capacity = 1.7,
                    Description = "Prepare hot drinks in no time with 2200W of power",
                    ManufacturerCountry = "China",
                    Price = 2349,
                    Quantity = 13,
                    WarrantyInMonths = 24,
                    CatalogId = 1
                },
                new Product
                {
                    Title = "Teapot Philips Viva Collection HD9355/92",
                    ImgUrl = "https://content2.rozetka.com.ua/goods/images/big_tile/274310222.jpg",
                    Capacity = 1.7,
                    Description = "With keep warm function; fast, safe boiling; easy to fill, use and clean",
                    ManufacturerCountry = "China",
                    Price = 2399,
                    Quantity = 7,
                    WarrantyInMonths = 24,
                    CatalogId = 1
                },
                new Product
                {
                    Title = "Teapot AENO EK4",
                    ImgUrl = "https://content2.rozetka.com.ua/goods/images/big_tile/248635439.jpg",
                    Capacity = 1.5,
                    Description = "With the AENO EK4 electric kettle, you can boil water in just 5 " +
                    "minutes and have time to prepare tea or coffee for the arrival of guests.",
                    ManufacturerCountry = "China",
                    Price = 1099,
                    Quantity = 9,
                    WarrantyInMonths = 24,
                    CatalogId = 1
                },
                new Product
                {
                    Title = "Teapot 7",
                    ImgUrl = "https://content.rozetka.com.ua/goods/images/big_tile/14708920.jpg",
                    Capacity = 1.5,
                    Description = "Good teapot",
                    ManufacturerCountry = "China",
                    Price = 1399,
                    Quantity = 9,
                    WarrantyInMonths = 12,
                    CatalogId = 1
                },
                new Product
                {
                    Title = "Teapot 8",
                    ImgUrl = "https://content1.rozetka.com.ua/goods/images/big_tile/283417981.png",
                    Capacity = 1.5,
                    Description = "Good teapot",
                    ManufacturerCountry = "China",
                    Price = 1469,
                    Quantity = 9,
                    WarrantyInMonths = 12,
                    CatalogId = 1
                },
                new Product
                {
                    Title = "Teapot 9",
                    ImgUrl = "https://content1.rozetka.com.ua/goods/images/big_tile/10626237.jpg",
                    Capacity = 1.5,
                    Description = "Good teapot",
                    ManufacturerCountry = "China",
                    Price = 1599,
                    Quantity = 9,
                    WarrantyInMonths = 12,
                    CatalogId = 1
                },
                new Product
                {
                    Title = "Teapot 10",
                    ImgUrl = "https://content1.rozetka.com.ua/goods/images/big_tile/81865256.jpg",
                    Capacity = 1.5,
                    Description = "Good teapot",
                    ManufacturerCountry = "China",
                    Price = 2399,
                    Quantity = 9,
                    WarrantyInMonths = 12,
                    CatalogId = 1
                },
                new Product
                {
                    Title = "Teapot 11",
                    ImgUrl = "https://content.rozetka.com.ua/goods/images/big_tile/142971427.jpg",
                    Capacity = 1.5,
                    Description = "Good teapot",
                    ManufacturerCountry = "China",
                    Price = 2899,
                    Quantity = 9,
                    WarrantyInMonths = 12,
                    CatalogId = 1
                },
                new Product
                {
                    Title = "Teapot 12",
                    ImgUrl = "https://content.rozetka.com.ua/goods/images/big_tile/163131692.jpg",
                    Capacity = 1.5,
                    Description = "Good teapot",
                    ManufacturerCountry = "China",
                    Price = 2229,
                    Quantity = 9,
                    WarrantyInMonths = 12,
                    CatalogId = 1
                }, 
                new Product {
                    Title = "Coffee machine 1",
                    Quantity = 9,
                    Price = 2229,
                    ImgUrl = "https://content.rozetka.com.ua/goods/images/big_tile/160433459.jpg",
                    Description = "Good teapot",
                    ManufacturerCountry = "China",
                    Capacity = 12,
                    WarrantyInMonths = 12,
                    CatalogId = 2
                },
                new Product
                {
                    Title = "Coffee machine 2",
                    Quantity = 3,
                    Price = 1579,
                    ImgUrl = "https://content.rozetka.com.ua/goods/images/big_tile/15790055.jpg",
                    Description = "Good teapot",
                    ManufacturerCountry = "China",
                    Capacity = 12,
                    WarrantyInMonths = 24,
                    CatalogId = 2
                },
                new Product
                {
                    Title = "Coffee machine 3",
                    Quantity = 5,
                    Price = 2379,
                    ImgUrl = "https://content2.rozetka.com.ua/goods/images/big_tile/29270053.jpg",
                    Description = "Good teapot",
                    ManufacturerCountry = "China",
                    Capacity = 12,
                    WarrantyInMonths = 18,
                    CatalogId = 2
                },
                new Product
                {
                    Title = "Coffee machine 4",
                    Quantity = 17,
                    Price = 1899,
                    ImgUrl = "https://content2.rozetka.com.ua/goods/images/big_tile/160392353.jpg",
                    Description = "Good teapot",
                    ManufacturerCountry = "China",
                    Capacity = 12,
                    WarrantyInMonths = 12,
                    CatalogId = 2
                },
                new Product
                {
                    Title = "Coffee machine 5",
                    Quantity = 3,
                    Price = 1989,
                    ImgUrl = "https://content.rozetka.com.ua/goods/images/big_tile/76717007.jpg",
                    Description = "Good teapot",
                    ManufacturerCountry = "China",
                    Capacity = 12,
                    WarrantyInMonths = 6,
                    CatalogId = 2
                },
                new Product
                {
                    Title = "Coffee machine 6",
                    Quantity = 9,
                    Price = 2359,
                    ImgUrl = "https://content.rozetka.com.ua/goods/images/big_tile/45610581.jpg",
                    Description = "Good teapot",
                    ManufacturerCountry = "China",
                    Capacity = 12,
                    WarrantyInMonths = 30,
                    CatalogId = 2
                },
                new Product
                {
                    Title = "Coffee machine 7",
                    Quantity = 10,
                    Price = 3599,
                    ImgUrl = "https://content1.rozetka.com.ua/goods/images/big_tile/160843463.jpg",
                    Description = "Good teapot",
                    ManufacturerCountry = "China",
                    Capacity = 12,
                    WarrantyInMonths = 24,
                    CatalogId = 2
                },
                new Product
                {
                    Title = "Coffee machine 8",
                    Quantity = 8,
                    Price = 4179,
                    ImgUrl = "https://content.rozetka.com.ua/goods/images/big_tile/167686386.jpg",
                    Description = "Good teapot",
                    ManufacturerCountry = "China",
                    Capacity = 12,
                    WarrantyInMonths = 6,
                    CatalogId = 2
                },
                new Product
                {
                    Title = "Coffee machine 9",
                    Quantity = 5,
                    Price = 1789,
                    ImgUrl = "https://content.rozetka.com.ua/goods/images/big_tile/13821301.jpg",
                    Description = "Good teapot",
                    ManufacturerCountry = "China",
                    Capacity = 12,
                    WarrantyInMonths = 24,
                    CatalogId = 2
                },
                new Product
                {
                    Title = "Coffee machine 10",
                    Quantity = 7,
                    Price = 6789,
                    ImgUrl = "https://content2.rozetka.com.ua/goods/images/big_tile/11675316.jpg",
                    Description = "Good teapot",
                    ManufacturerCountry = "China",
                    Capacity = 12,
                    WarrantyInMonths = 12,
                    CatalogId = 2
                });
        }
    }
}
