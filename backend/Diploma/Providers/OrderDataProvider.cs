using Microsoft.EntityFrameworkCore;
using Diploma.DB;
using Diploma.Interfaces;
using Diploma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.Providers
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

        public async Task<List<Order>> GetOrders(Guid userId)
        {
            var orders = await _dbContext.Orders.Where(o => o.UserId == userId).ToListAsync();

            return orders;
        }
    }
}
