using Microsoft.EntityFrameworkCore;
using Module6HW7.DB;
using Module6HW7.Interfaces;
using Module6HW7.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module6HW7.Providers
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
