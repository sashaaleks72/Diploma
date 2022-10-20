using AutoMapper;
using Diploma.Exceptions;
using Diploma.Interfaces;
using Diploma.Models;
using Diploma.Services;
using Diploma.ViewModels;
using Moq;

namespace Diploma.Tests
{
    public class ProductServiceTests
    {
        [Fact]
        public async Task GetProducts_IfDbIsEmpty_BusinessException()
        {
            /* Arrange */
            var mockDataProvider = new Mock<IProductsDataProvider>();
            mockDataProvider.Setup(p => p.GetProducts(null, null, null, 0, 0)).Returns(Task.FromResult(new List<Product>()));

            var productService = new ProductService(mockDataProvider.Object, It.IsAny<IMapper>());
            /* Act */

            /* Assert */
            await Assert.ThrowsAsync<BusinessException>(async () => await productService.GetProducts());
        }

        [Fact]
        public async Task GetProducts_IfDbIsNotEmpty_Teapots()
        {
            /* Arrange */
            var mockDataProvider = new Mock<IProductsDataProvider>();
            mockDataProvider.Setup(p => p.GetProducts(null, null, null, 0, 0)).Returns(Task.FromResult(new List<Product>() { It.IsAny<Product>() }));

            var productService = new ProductService(mockDataProvider.Object, It.IsAny<IMapper>());

            /* Act */
            var products = await productService.GetProducts();

            /* Assert */
            Assert.NotEmpty(products);
        }

        [Fact]
        public async Task GetProductById_IfIsNull_BusinessException()
        {
            /* Arrange */
            var mockDataProvider = new Mock<IProductsDataProvider>();
            mockDataProvider.Setup(p => p.GetProductById(It.IsAny<Guid>())).Returns(Task.FromResult<Product>(null));

            var productService = new ProductService(mockDataProvider.Object, It.IsAny<IMapper>());

            /* Act */

            /* Assert */
            await Assert.ThrowsAsync<BusinessException>(async () => await productService.GetProductById(It.IsAny<Guid>()));
        }

        [Fact]
        public async Task GetProductById_IfExists_Product()
        {
            /* Arrange */
            var mockDataProvider = new Mock<IProductsDataProvider>();
            mockDataProvider.Setup(p => p.GetProductById(It.IsAny<Guid>())).Returns(Task.FromResult(new Product()));

            var productService = new ProductService(mockDataProvider.Object, It.IsAny<IMapper>());
            /* Act */
            var recievedProduct = await productService.GetProductById(It.IsAny<Guid>());

            /* Assert */
            Assert.NotNull(recievedProduct);
        }

        [Fact]
        public async Task AddTeapot_IfAdded_True()
        {
            /* Arrange */
            var mockDataProvider = new Mock<IProductsDataProvider>();
            mockDataProvider.Setup(p => p.AddProduct(It.IsAny<Product>())).Returns(Task.FromResult(true));
            var mockMapper = new Mock<IMapper>();

            var productService = new ProductService(mockDataProvider.Object, mockMapper.Object);
            /* Act */
            var isAdded = await productService.AddProduct(It.IsAny<ProductViewModel>());

            /* Assert */
            Assert.True(isAdded);
        }

        [Fact]
        public async Task EditTeapotById_IfChanged_True()
        {
            /* Arrange */
            var mockDataProvider = new Mock<IProductsDataProvider>();

            mockDataProvider
                .Setup(p => p.GetProductById(It.IsAny<Guid>()))
                .Returns(Task.FromResult(new Product()));
            mockDataProvider
                .Setup(p => p.EditProduct(It.IsAny<Product>()))
                .Returns(Task.FromResult(true));
            var mockMapper = new Mock<IMapper>();

            var teapotService = new ProductService(mockDataProvider.Object, mockMapper.Object);
            /* Act */
            var isChanged = await teapotService.EditProductById(It.IsAny<Guid>(), new Product());

            /* Assert */
            Assert.True(isChanged);
        }

        [Fact]
        public async Task EditTeapotById_IfNotFound_BusinessException()
        {
            /* Arrange */
            var mockDataProvider = new Mock<IProductsDataProvider>();

            mockDataProvider
                .Setup(p => p.GetProductById(It.IsAny<Guid>()))
                .Returns(Task.FromResult<Product>(null));
            var mockMapper = new Mock<IMapper>();

            var teapotService = new ProductService(mockDataProvider.Object, mockMapper.Object);
            /* Act */

            /* Assert */
            await Assert.ThrowsAsync<BusinessException>(async () => await teapotService.EditProductById(It.IsAny<Guid>(), It.IsAny<Product>()));
        }

        [Fact]
        public async Task DeleteTeapotById_IfDeleted_True()
        {
            /* Arrange */
            var mockDataProvider = new Mock<IProductsDataProvider>();

            mockDataProvider
                .Setup(p => p.GetProductById(It.IsAny<Guid>()))
                .Returns(Task.FromResult(new Product()));
            mockDataProvider
                .Setup(p => p.DeleteProduct(It.IsAny<Product>()))
                .Returns(Task.FromResult(true));
            var mockMapper = new Mock<IMapper>();

            var teapotService = new ProductService(mockDataProvider.Object, mockMapper.Object);
            /* Act */
            var isDeleted = await teapotService.DeleteProductById(It.IsAny<Guid>());

            /* Assert */
            Assert.True(isDeleted);
        }

        [Fact]
        public async Task DeleteTeapotById_IfNotFound_BusinessException()
        {
            /* Arrange */
            var mockDataProvider = new Mock<IProductsDataProvider>();

            mockDataProvider
                .Setup(p => p.GetProductById(It.IsAny<Guid>()))
                .Returns(Task.FromResult<Product>(null));
            var mockMapper = new Mock<IMapper>();

            var teapotService = new ProductService(mockDataProvider.Object, mockMapper.Object);
            /* Act */

            /* Assert */
            await Assert.ThrowsAsync<BusinessException>(async () => await teapotService.DeleteProductById(It.IsAny<Guid>()));
        }
    }
}