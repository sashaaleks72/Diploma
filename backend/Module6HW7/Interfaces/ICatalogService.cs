using Module6HW7.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Module6HW7.Interfaces
{
    public interface ICatalogService
    {
        public Task<List<Catalog>> GetCatalogItems();
    }
}
