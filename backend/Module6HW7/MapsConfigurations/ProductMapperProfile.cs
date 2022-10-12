using AutoMapper;
using Module6HW7.DB;
using Module6HW7.Models;
using Module6HW7.ResponseModels;
using Module6HW7.ViewModels;
using System.Linq;

namespace Module6HW7.MapsConfigurations
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<Product, ProductResponse>()
                .ForMember(destination => destination.ProductType,
                           options => options.MapFrom(source => source.Catalog.Title));

            CreateMap<ProductViewModel, Product>()
                .AfterMap<DbAction>();
        }
    }

    public class DbAction : IMappingAction<ProductViewModel, Product>
    {
        private readonly ApplicationDbContext _dbContext;

        public DbAction(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Process(ProductViewModel source, Product destination, ResolutionContext context)
        {
            destination.Catalog = _dbContext.CatalogItems.FirstOrDefault(catalogItem => catalogItem.Title == source.ProductType);
        }
    }
}
