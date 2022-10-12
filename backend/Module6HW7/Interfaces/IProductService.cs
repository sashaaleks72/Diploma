﻿using Module6HW7.Models;
using Module6HW7.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Module6HW7.Interfaces
{
    public interface IProductService
    {
        public Task<List<Product>> GetProducts(string productType, string sort, string order, int page, int limit);

        public Task<Product> GetProductById(Guid id);

        public Task<bool> AddProduct(ProductViewModel productModel);

        public Task<bool> EditProductById(Guid id, Product productModel);

        public Task<bool> DeleteProductById(Guid id);
    }
}
