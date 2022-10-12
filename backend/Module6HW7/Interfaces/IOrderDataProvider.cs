using Module6HW7.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Module6HW7.Interfaces
{
    public interface IOrderDataProvider
    {
        public Task<bool> AddOrderProduct(List<OrderProduct> orderProducts);

        public Task<bool> AddOrder(Order order);

        public Task<List<Order>> GetOrders();

        public Task<List<OrderProduct>> GetOrderProductsByOrderId(int orderId);
    }
}
