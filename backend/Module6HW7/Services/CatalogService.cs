using Module6HW7.Exceptions;
using Module6HW7.Interfaces;
using Module6HW7.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Module6HW7.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogDataProvider _dataProvider;

        public CatalogService(ICatalogDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<List<Catalog>> GetCatalogItems()
        {
            var catalogItems = await _dataProvider.GetCatalogItems();

            if (catalogItems == null) throw new BusinessException("There are no entries in the table!");

            return catalogItems;
        }
    }
}
