using Catalogo.API.Entities;
using MongoDB.Driver;

namespace Catalogo.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if(!existProduct)
            {
                productCollection.InsertManyAsync(GetMyProducts());
            }
        }

        private static IEnumerable<Product> GetMyProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = "132",
                    Name = "Pc com RTX3070",
                    Description = "Um computador com uma boa placa de video para jogos.",
                    Image = "placadevideo.png",
                    Price = 4.55M,
                    Category = "Hardware"
                },
                new Product()
                {
                    Id = "2547",
                    Name = "POCO F4 GT",
                    Description = "Um Celular para jogos.",
                    Image = "smartphone.png",
                    Price = 9.55M,
                    Category = "Smartphone"
                },
                new Product()
                {
                    Id = "12999",
                    Name = "Guitarra lespooll",
                    Description = "Instrumento musical.",
                    Image = "guitar.png",
                    Price = 3.25M,
                    Category = "InstrumentoMusical"
                },
                new Product()
                {
                    Id = "85544",
                    Name = "Monitor Acer Predador",
                    Description = "Monitor com G-sync",
                    Image = "monitorAcer.png",
                    Price = 8.25M,
                    Category = "Hardware"
                },

            };
        }
    }
}
