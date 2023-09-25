using Catalogo.API.Entities;
using MongoDB.Driver;

namespace Catalogo.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            // Configurando a conexionstring
            var client = new MongoClient(configuration.GetValue<string>
                ("DatabaseSettings:ConnectionString"));

            // Nome do banco de dados
            var database = client.GetDatabase(configuration.GetValue<string>
                ("DatabaseSettings:DatabaseName"));

            // Nome da coleção
            Products = database.GetCollection<Product>(configuration.GetValue<string>
                ("DatabaseSettings:CollectionName"));

            //CatalogContextSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}
