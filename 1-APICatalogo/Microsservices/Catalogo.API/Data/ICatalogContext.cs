using Catalogo.API.Entities;
using MongoDB.Driver;

namespace Catalogo.API.Data
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
