using Jwt.Models;

namespace Jwt.Constants
{
    public class ProductContants
    {
        public static List<ProductModel> Products = new List<ProductModel>()
        {
            new ProductModel() { Name= "Play Station 5", Description = "Consola de 5ta generación"},
            new ProductModel() { Name= "MackBook Pro", Description = "Laptop Mamalón"},
            new ProductModel() { Name= "Iphone 15", Description = "Celular Mamalón"},
        };
    }
}
