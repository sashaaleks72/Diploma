using Diploma.ResponseModels;
using Diploma.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diploma.Interfaces
{
    public interface IOrderService
    {
        public Task<bool> MakeAnOrder(OrderViewModel orderViewModel);

        public Task<List<OrderResponse>> GetOrders(Guid userId);
    }
}
