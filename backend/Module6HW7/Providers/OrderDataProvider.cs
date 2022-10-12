using Microsoft.EntityFrameworkCore;
using Module6HW7.DB;
using Module6HW7.Interfaces;
using Module6HW7.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module6HW7.Providers
{
    public class OrderDataProvider : IOrderDataProvider
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderDataProvider(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddOrder(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            int quanOfAddedEntries = await _dbContext.SaveChangesAsync();

            return quanOfAddedEntries > 0;
        }

        public async Task<bool> AddOrderProduct(List<OrderProduct> orderProducts)
        {
            await _dbContext.OrderProducts.AddRangeAsync(orderProducts);
            int quanOfAddedEntries = await _dbContext.SaveChangesAsync();

            return quanOfAddedEntries > 0;
        }

        public async Task<List<OrderProduct>> GetOrderProductsByOrderId(int orderId)
        {
            var orderProducts = await _dbContext.OrderProducts.Where(orderProduct => orderProduct.OrderId == orderId).ToListAsync();

            return orderProducts;
        }

        public async Task<List<Order>> GetOrders()
        {
            var orders = await _dbContext.Orders.ToListAsync();

            return orders;
        }
    }
}
