using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Diploma.Exceptions;
using Diploma.Interfaces;
using Diploma.Models;
using Diploma.ResponseModels;
using Diploma.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diploma.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetProducts(string productType, string sort, string order, int page, int limit)
        {
            List<Product> products = null;
            
            try
            {
                products = await _productService.GetProducts(productType, sort, order, page, limit);
            }
            catch (BusinessException ex)
            {
                return NotFound(new { ex.Message });
            }

            return Ok(products);
        } 

        [HttpGet("products/{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] Guid id)
        {
            ProductResponse responseProduct = null;

            try
            {
                responseProduct = _mapper.Map<Product, ProductResponse>(await _productService.GetProductById(id));
            }
            catch (BusinessException ex)
            {
                return NotFound(new { ex.Message });
            }

            return Ok(responseProduct);
        }

        [HttpPost("products")]
        public async Task<IActionResult> AddProduct([FromBody] ProductViewModel productFromBody)
        {
            await _productService.AddProduct(productFromBody);

            return Ok(new {SuccessMessage = "The product has been added!"});
        }


        [HttpPut("products/{id}")]
        public async Task<IActionResult> EditProductById([FromRoute] Guid id, [FromBody] ProductViewModel productFromBody)
        {
            var productToEdit = _mapper.Map<ProductViewModel, Product>(productFromBody);

            try
            {
                await _productService.EditProductById(id, productToEdit);
            }
            catch (BusinessException ex)
            {
                return NotFound(new { ex.Message });
            }

            return Ok(new { SuccessMessage = "The product has been changed!" });
        }

        [HttpDelete("products/{id}")]
        public async Task<IActionResult> DeleteProductById([FromRoute] Guid id)
        {
            try
            {
                await _productService.DeleteProductById(id);
            }
            catch (BusinessException ex)
            {
                return NotFound(new { ex.Message });
            }

            return Ok(new { SuccessMessage = "The product has been removed!" });
        }
    }
}
