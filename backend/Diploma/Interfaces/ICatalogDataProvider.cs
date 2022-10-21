using Diploma.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diploma.Interfaces
{
    public interface ICatalogDataProvider
    {
        public Task<List<Catalog>> GetCatalogItems();
    }
}
