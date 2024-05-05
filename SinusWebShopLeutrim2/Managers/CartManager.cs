using SinusWebShopLeutrim2.Models;

namespace SinusWebShopLeutrim2.Managers
{
    public class CartManager
    {
        public static List<Product> Cart { get; set; } = new List<Product>();

        public static double? GetTotalPrice()
        {
            return Cart.Sum(p => p.Price);
        }

        public static void AddToCart(Product product)
        {
            Cart.Add(product);
        }

        public static void RemoveFromCart(Product product)
        {
            Cart.Remove(product);
        }
    }
}
