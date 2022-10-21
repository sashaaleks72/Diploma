using Microsoft.EntityFrameworkCore;
using Diploma.DB;
using Diploma.Interfaces;
using Diploma.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.Providers
{
    public class CatalogDataProvider : ICatalogDataProvider
    {
        private readonly ApplicationDbContext _dbContext;

        public CatalogDataProvider(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Catalog>> GetCatalogItems()
        {
            var catalogItems = await _dbContext.CatalogItems.ToListAsync();

            return catalogItems;
        }
    }
}
