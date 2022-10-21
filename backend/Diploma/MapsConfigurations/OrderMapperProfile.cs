using AutoMapper;
using Diploma.DB;
using Diploma.Models;
using Diploma.ResponseModels;
using Diploma.ViewModels;

namespace Diploma.MapsConfigurations
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
