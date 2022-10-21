using AutoMapper;
using Diploma.DB;
using Diploma.Models;
using Diploma.ResponseModels;
using Diploma.ViewModels;
using System.Linq;

namespace Diploma.MapsConfigurations
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<Product, ProductResponse>()
                .ForMember(destination => destination.ProductType,
                           options => options.MapFrom(source => source.Catalog.Title));

            CreateMap<ProductViewModel, Product>()
                .AfterMap<DbSetCatalogMappingAction>();
        }
    }

    public class DbSetCatalogMappingAction : IMappingAction<ProductViewModel, Product>
    {
        private readonly ApplicationDbContext _dbContext;

        public DbSetCatalogMappingAction(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Process(ProductViewModel source, Product destination, ResolutionContext context)
        {
            destination.Catalog = _dbContext.CatalogItems.FirstOrDefault(catalogItem => catalogItem.Title == source.ProductType);
        }
    }
}
