﻿using Module6HW7.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Module6HW7.Interfaces
{
    public interface IProductsDataProvider
    {
        public Task<List<Product>> GetProducts(string productType, string sort, string order, int page, int limit);

        public Task<Product> GetProductById(Guid id);

        public Task<bool> AddProduct(Product product);

        public Task<bool> EditProduct(Product product);

        public Task<bool> DeleteProduct(Product product);
    }
}
