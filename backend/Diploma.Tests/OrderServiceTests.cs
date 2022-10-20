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
    public class OrderServiceTests
    {
        [Fact]
        public async Task MakeAnOrder_IsCompleted_True()
        {
            // arrange
            var orderViewModel = new OrderViewModel()
            {
                CartItems = new List<CartItemViewModel>()
            };

            var mockOrderDataProvider = new Mock<IOrderDataProvider>();
            var mockMapper = new Mock<IMapper>();

            mockOrderDataProvider
                .Setup(o => o.AddOrder(It.IsAny<Order>()))
                .Returns(Task.FromResult(true));
            mockOrderDataProvider
                .Setup(o => o.AddOrderProduct(It.IsAny<List<OrderProduct>>()))
                .Returns(Task.FromResult(true));
            mockMapper.Setup(m => m.Map<OrderViewModel, Order>(It.IsAny<OrderViewModel>())).Returns(new Order());

            var orderService = new OrderService(mockOrderDataProvider.Object, mockMapper.Object);

            // act
            bool actual = await orderService.MakeAnOrder(orderViewModel);

            // assert
            Assert.True(actual);
        }

        [Fact]
        public async Task GetOrders_OrderProductsListIsEmpty_BusinessException()
        {
            // arrange
            var mockOrderDataProvider = new Mock<IOrderDataProvider>();
            var mockMapper = new Mock<IMapper>();

            mockOrderDataProvider
                .Setup(o => o.GetOrders(It.IsAny<Guid>()))
                .Returns(Task.FromResult(new List<Order>
                {
                    new Order()
                }));
            mockOrderDataProvider
                .Setup(o => o.GetOrderProductsByOrderId(It.IsAny<int>()))
                .Returns(Task.FromResult(new List<OrderProduct>()));

            mockMapper.Setup(m => m.Map<Order, OrderResponse>(It.IsAny<Order>())).Returns(new OrderResponse());

            var orderService = new OrderService(mockOrderDataProvider.Object, mockMapper.Object);

            // act

            // assert
            await Assert.ThrowsAsync<BusinessException>(async () => await orderService.GetOrders(Guid.NewGuid()));
        }

        [Fact]
        public async Task GetOrders_OrderProductsListIsNotEmpty_ListOfOrderResponse()
        {
            // arrange
            var mockOrderDataProvider = new Mock<IOrderDataProvider>();
            var mockMapper = new Mock<IMapper>();

            mockOrderDataProvider
                .Setup(o => o.GetOrders(It.IsAny<Guid>()))
                .Returns(Task.FromResult(new List<Order>
                {
                    new Order()
                }));
            mockOrderDataProvider
                .Setup(o => o.GetOrderProductsByOrderId(It.IsAny<int>()))
                .Returns(Task.FromResult(new List<OrderProduct>
                {
                    new OrderProduct
                    {
                        Product = new Product()
                    }
                }));

            mockMapper.Setup(m => m.Map<Order, OrderResponse>(It.IsAny<Order>())).Returns(new OrderResponse());

            var orderService = new OrderService(mockOrderDataProvider.Object, mockMapper.Object);

            // act
            var orderResponses = await orderService.GetOrders(Guid.NewGuid());

            // assert
            Assert.NotEmpty(orderResponses);
        }
    }
}
