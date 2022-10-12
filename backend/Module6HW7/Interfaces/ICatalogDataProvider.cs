using Module6HW7.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Module6HW7.Interfaces
{
    public interface ICatalogDataProvider
    {
        public Task<List<Catalog>> GetCatalogItems();
    }
}
