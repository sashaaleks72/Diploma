using Diploma.Exceptions;
using Diploma.Interfaces;
using Diploma.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diploma.Services
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

            if (catalogItems.Count == 0) throw new BusinessException("There are no entries in the table!");

            return catalogItems;
        }
    }
}
