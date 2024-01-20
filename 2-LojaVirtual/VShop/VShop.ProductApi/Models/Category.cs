namespace VShop.ProductApi.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }

        //Propriedade de navegação.
        public ICollection<Product> Products { get; set; }
    }
}
