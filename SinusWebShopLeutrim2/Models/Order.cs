namespace SinusWebShopLeutrim2.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }

    public class OrderItem
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public int Quantity { get; set; }
    }

}
