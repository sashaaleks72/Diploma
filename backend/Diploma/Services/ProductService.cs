using AutoMapper;
using Diploma.Exceptions;
using Diploma.Interfaces;
using Diploma.Models;
using Diploma.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diploma.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductsDataProvider _dataProvider;
        private readonly IMapper _mapper;

        public ProductService(IProductsDataProvider dataProvider, IMapper mapper)
        {
            _dataProvider = dataProvider;
            _mapper = mapper;
        }

        public async Task<List<Product>> GetProducts(string productType, string sort, string order, int page, int limit)
        {
            var teapots = await _dataProvider.GetProducts(productType, sort, order, page, limit);

            if (teapots.Count == 0)
            {
                throw new BusinessException("There are no entires returned from the db!");
            }

            return teapots;
        }

        public async Task<Product> GetProductById(Guid id)
        {
            var product = await _dataProvider.GetProductById(id);

            if (product == null)
            {
                throw new BusinessException("Product with this id is absent!");
            }

            return product;
        }

        public async Task<bool> AddProduct(ProductViewModel productModel)
        {
            var product = _mapper.Map<ProductViewModel, Product>(productModel);

            return await _dataProvider.AddProduct(product);
        }

        public async Task<bool> EditProductById(Guid id, Product productModel)
        {
            var editedProduct = await _dataProvider.GetProductById(id);

            if (editedProduct == null)
            {
                throw new BusinessException("Product with this id is absent!");
            }

            editedProduct.Title = productModel.Title;
            editedProduct.Price = productModel.Price;
            editedProduct.Description = productModel.Description;
            editedProduct.Capacity = productModel.Capacity;
            editedProduct.Quantity = productModel.Quantity;
            editedProduct.ImgUrl = productModel.ImgUrl;
            editedProduct.ManufacturerCountry = productModel.ManufacturerCountry;
            editedProduct.WarrantyInMonths = productModel.WarrantyInMonths;
            editedProduct.Catalog = productModel.Catalog;

            return await _dataProvider.EditProduct(editedProduct);
        }

        public async Task<bool> DeleteProductById(Guid id)
        {
            var productToDelete = await _dataProvider.GetProductById(id);

            if (productToDelete == null)
            {
                throw new BusinessException("Product with this id is absent!");
            }

            return await _dataProvider.DeleteProduct(productToDelete);
        }
    }
}
