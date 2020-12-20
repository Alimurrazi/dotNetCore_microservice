using AspnetRunBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRunBasics.ApiCollection.Interfaces
{
    public interface ICatalogApi
    {
        Task<IEnumerable<CatalogModel>> GetCatalog();
        Task<IEnumerable<CatalogModel>> GetCatalogByCategory(string category);
        Task<IEnumerable<CatalogModel>> GetCatalog(string id);
        Task<IEnumerable<CatalogModel>> CreateCatalog(CatalogModel model);
    }
}
