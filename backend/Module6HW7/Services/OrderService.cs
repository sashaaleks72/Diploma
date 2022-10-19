using AutoMapper;
using Module6HW7.Exceptions;
using Module6HW7.Interfaces;
using Module6HW7.Models;
using Module6HW7.ResponseModels;
using Module6HW7.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Module6HW7.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderDataProvider _dataProvider;
        private readonly IMapper _mapper;

        public OrderService(IOrderDataProvider dataProvider, IMapper mapper)
        {
            _dataProvider = dataProvider;
            _mapper = mapper;
        }

        public async Task<List<OrderResponse>> GetOrders(Guid userId)
        {
            List<Order> orders = null;

            if (userId.Equals(Guid.Empty))
            {
                orders = await _dataProvider.GetOrders();
            }
            else
            {
                orders = await _dataProvider.GetOrders(userId);
            }
             
            var ordersResponse = new List<OrderResponse>();
            List<OrderProduct> orderProducts = null;

            foreach (var order in orders) {
                var orderResponse = _mapper.Map<Order, OrderResponse>(order);
                orderResponse.CartItems = new List<CartItemResponse>();

                orderProducts = await _dataProvider.GetOrderProductsByOrderId(order.Id);

                if (orderProducts.Count == 0)
                {
                    throw new BusinessException("There are no orderProducts by current order id");
                }

                foreach (var orderProduct in orderProducts)
                {
                    orderResponse.CartItems.Add(new CartItemResponse
                    {
                        Title = orderProduct.Product.Title,
                        ImgUrl = orderProduct.Product.ImgUrl,
                        Price = orderProduct.Price,
                        Quantity = orderProduct.Quantity
                    });
                }

                ordersResponse.Add(orderResponse);
            }

            return ordersResponse;
        }

        public async Task<bool> MakeAnOrder(OrderViewModel orderViewModel)
        {
            var order = _mapper.Map<OrderViewModel, Order>(orderViewModel);
            order.OrderDate = DateTime.Now;
            order.OrderStatusId = 1; // 1 - Awaiting confirmation

            var orderProducts = new List<OrderProduct>();

            for (int i = 0; i < orderViewModel.CartItems.Count; i++)
            {
                orderProducts.Add(new OrderProduct
                {
                    Price = orderViewModel.CartItems[i].Price,
                    Quantity = orderViewModel.CartItems[i].Quantity,
                    ProductId = orderViewModel.CartItems[i].Id,
                    Order = order
                });
            }

            bool isOrderAdded = await _dataProvider.AddOrder(order);
            bool isOrderProductAdded = await _dataProvider.AddOrderProduct(orderProducts);

            return isOrderAdded && isOrderProductAdded;
        }
    }
}
