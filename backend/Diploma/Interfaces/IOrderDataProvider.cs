using Diploma.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diploma.Interfaces
{
    public interface IOrderDataProvider
    {
        public Task<bool> AddOrderProduct(List<OrderProduct> orderProducts);

        public Task<bool> AddOrder(Order order);

        public Task<List<Order>> GetOrders();

        public Task<List<Order>> GetOrders(Guid userId);

        public Task<List<OrderProduct>> GetOrderProductsByOrderId(int orderId);
    }
}
