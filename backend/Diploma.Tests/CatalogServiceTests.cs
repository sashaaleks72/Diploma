using AutoMapper;
using Diploma.Exceptions;
using Diploma.Interfaces;
using Diploma.Models;
using Diploma.ResponseModels;
using Diploma.Services;
using Diploma.ViewModels;
using Moq;

namespace Diploma.Tests
{
    public class CatalogServiceTests
    {
        [Fact]
        public async Task GetOrders_OrderProductsListIsEmpty_BusinessException()
        {
            // arrange
            var mockCatalogDataProvider = new Mock<ICatalogDataProvider>();

            mockCatalogDataProvider
                .Setup(c => c.GetCatalogItems())
                .Returns(Task.FromResult(new List<Catalog>()));

            var catalogService = new CatalogService(mockCatalogDataProvider.Object);

            // act

            // assert
            await Assert.ThrowsAsync<BusinessException>(async () => await catalogService.GetCatalogItems());
        }

        [Fact]
        public async Task GetOrders_OrderProductsListIsNotEmpty_ListOfOrderResponse()
        {
            // arrange
            var mockCatalogDataProvider = new Mock<ICatalogDataProvider>();

            mockCatalogDataProvider
                .Setup(c => c.GetCatalogItems())
                .Returns(Task.FromResult(new List<Catalog>
                {
                    new Catalog()
                }));

            var catalogService = new CatalogService(mockCatalogDataProvider.Object);

            // act
            var catalogItems = await catalogService.GetCatalogItems();

            // assert
            Assert.NotEmpty(catalogItems);
        }
    }
}
