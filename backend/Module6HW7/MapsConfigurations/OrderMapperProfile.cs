using AutoMapper;
using Module6HW7.DB;
using Module6HW7.Models;
using Module6HW7.ResponseModels;
using Module6HW7.ViewModels;

namespace Module6HW7.MapsConfigurations
{
    public class OrderMapperProfile : Profile
    {
        public OrderMapperProfile()
        {
            CreateMap<OrderViewModel, Order>();
            CreateMap<Order, OrderResponse>()
                .ForMember(destination => destination.OrderDate, options => options.MapFrom(source => source.OrderDate.ToString("dd-MM-yyyy")))
                .ForMember(destination => destination.OrderStatus, options => options.MapFrom(source => source.OrderStatus.Title));
        }
    }
}
