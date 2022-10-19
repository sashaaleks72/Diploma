using Diploma.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diploma.Interfaces
{
    public interface ICatalogService
    {
        public Task<List<Catalog>> GetCatalogItems();
    }
}
