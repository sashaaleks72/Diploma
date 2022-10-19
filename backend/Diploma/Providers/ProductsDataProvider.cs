using Microsoft.EntityFrameworkCore;
using Diploma.DB;
using Diploma.Interfaces;
using Diploma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.Providers
{
    public class ProductsDataProvider : IProductsDataProvider
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductsDataProvider(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetProducts(string productType, string sort, string order, int page, int limit)
        {
            IQueryable<Product> products = _dbContext.Products;

            if (productType != null)
            {
                products = products.Where(p => p.Catalog.Title == productType);
            }

            if (sort != null && order != null)
            {
                products = order == "asc" ? products.OrderBy(p => p.Title) : products.OrderByDescending(p => p.Title);
            }

            products = limit == 0 || page == 0
                ? products
                : products.Skip(limit * (page - 1)).Take(limit);
            
            return await products.ToListAsync();
        }

        public async Task<Product> GetProductById(Guid id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

            return product;
        }

        public async Task<bool> AddProduct(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            int quanOfAddedProducts = await _dbContext.SaveChangesAsync();

            var isAdded = quanOfAddedProducts > 0;

            return isAdded;
        }

        public async Task<bool> EditProduct(Product product)
        {
            _dbContext.Update(product);
            int quanOfChangedProduct = await _dbContext.SaveChangesAsync();

            var isChanged = quanOfChangedProduct > 0;

            return isChanged;
        }

        public async Task<bool> DeleteProduct(Product product)
        {
            _dbContext.Products.Remove(product);
            int quanOfDeletedProducts = await _dbContext.SaveChangesAsync();

            var isRemoved = quanOfDeletedProducts > 0;

            return isRemoved;
        }
    }
}
