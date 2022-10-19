using Module6HW7.ResponseModels;
using Module6HW7.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Module6HW7.Interfaces
{
    public interface IOrderService
    {
        public Task<bool> MakeAnOrder(OrderViewModel orderViewModel);

        public Task<List<OrderResponse>> GetOrders(Guid userId);
    }
}
